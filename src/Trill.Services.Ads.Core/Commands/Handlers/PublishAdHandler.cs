using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Ads.Core.Clients;
using Trill.Services.Ads.Core.Clients.Requests;
using Trill.Services.Ads.Core.Domain;
using Trill.Services.Ads.Core.Domain.Exceptions;
using Trill.Services.Ads.Core.Events;

namespace Trill.Services.Ads.Core.Commands.Handlers
{
    internal sealed class PublishAdHandler : ICommandHandler<PublishAd>
    {
        private readonly IAdRepository _adRepository;
        private readonly IStoryApiClient _storyApiClient;
        private readonly IMessageBroker _messageBroker;

        public PublishAdHandler(IAdRepository adRepository, IStoryApiClient storyApiClient,
            IMessageBroker messageBroker)
        {
            _adRepository = adRepository;
            _storyApiClient = storyApiClient;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(PublishAd command)
        {
            var ad = await _adRepository.GetAsync(command.AdId);
            if (ad is null)
            {
                throw new AdNotFoundException(command.AdId);
            }

            ad.Publish();
            var storyId = await _storyApiClient.SendStoryAsync(new SendStoryRequest
            {
                UserId = ad.UserId,
                Title = ad.Header,
                Text = ad.Content,
                Tags = ad.Tags,
                Highlighted = true,
                VisibleFrom = ad.From,
                VisibleTo = ad.To
            });

            if (storyId is null)
            {
                throw new CannotPublishAdAException(command.AdId);
            }

            ad.SetStoryId(storyId.Value);
            await _adRepository.UpdateAsync(ad);
            await _messageBroker.PublishAsync(new AdPublished(ad.Id));
        }
    }
}