using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Ads.Core.Domain;

namespace Trill.Services.Ads.Core.Commands.Handlers
{
    internal sealed class CreateAdHandler : ICommandHandler<CreateAd>
    {
        private readonly IAdRepository _adRepository;

        public CreateAdHandler(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task HandleAsync(CreateAd command)
        {
            var ad = new Ad(command.AdId, command.UserId, command.Header, command.Content, command.Tags,
                AdState.New, command.From, command.To, DateTime.UtcNow);
            await _adRepository.AddAsync(ad);
        }
    }
}