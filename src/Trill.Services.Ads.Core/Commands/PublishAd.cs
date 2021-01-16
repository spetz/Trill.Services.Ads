using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Ads.Core.Commands
{
    public class PublishAd : ICommand
    {
        public Guid AdId { get; }

        public PublishAd(Guid adId)
        {
            AdId = adId;
        }
    }
}