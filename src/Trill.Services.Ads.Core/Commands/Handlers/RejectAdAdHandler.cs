using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Ads.Core.Domain;
using Trill.Services.Ads.Core.Domain.Exceptions;
using Trill.Services.Ads.Core.Events;

namespace Trill.Services.Ads.Core.Commands.Handlers
{
    internal sealed class RejectAdAdHandler : ICommandHandler<RejectAd>
    {
        private readonly IAdRepository _adRepository;
        private readonly IMessageBroker _messageBroker;

        public RejectAdAdHandler(IAdRepository adRepository, IMessageBroker messageBroker)
        {
            _adRepository = adRepository;
            _messageBroker = messageBroker;
        }
        
        public async Task HandleAsync(RejectAd command)
        {
            var ad = await _adRepository.GetAsync(command.AdId);
            if (ad is null)
            {
                throw new AdNotFoundException(command.AdId);
            }

            ad.Reject();
            await _adRepository.UpdateAsync(ad);
            await _messageBroker.PublishAsync(new AdRejected(ad.Id));
        }
    }
}