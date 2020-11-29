using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Ads.Core.Commands
{
    public class PayAd : ICommand
    {
        public Guid AdId { get; }

        public PayAd(Guid adId)
        {
            AdId = adId;
        }
    }
}