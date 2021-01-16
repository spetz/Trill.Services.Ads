using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Ads.Core.Commands
{
    public class ApproveAd : ICommand
    {
        public Guid AdId { get; }

        public ApproveAd(Guid adId)
        {
            AdId = adId;
        }
    }
}