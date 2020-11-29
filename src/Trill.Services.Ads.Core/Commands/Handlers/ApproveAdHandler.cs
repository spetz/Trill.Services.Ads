using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Ads.Core.Domain;
using Trill.Services.Ads.Core.Domain.Exceptions;
using Trill.Services.Ads.Core.Events;

namespace Trill.Services.Ads.Core.Commands.Handlers
{
    internal sealed class ApproveAdHandler : ICommandHandler<ApproveAd>
    {
        private readonly IAdRepository _adRepository;
        private readonly IMessageBroker _messageBroker;

        public ApproveAdHandler(IAdRepository adRepository, IMessageBroker messageBroker)
        {
            _adRepository = adRepository;
            _messageBroker = messageBroker;
        }
        
        public async Task HandleAsync(ApproveAd command)
        {
            var ad = await _adRepository.GetAsync(command.AdId);
            if (ad is null)
            {
                throw new AdNotFoundException(command.AdId);
            }

            ad.Approve();
            await _adRepository.UpdateAsync(ad);
            await _messageBroker.PublishAsync(new AdApproved(ad.Id));
        }
    }
}