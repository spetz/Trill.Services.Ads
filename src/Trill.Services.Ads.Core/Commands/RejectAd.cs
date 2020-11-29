using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Ads.Core.Commands
{
    public class RejectAd : ICommand
    {
        public Guid AdId { get; }
        public string Reason { get; }

        public RejectAd(Guid adId, string reason)
        {
            AdId = adId;
            Reason = reason;
        }
    }
}