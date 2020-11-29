using System;
using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core.Events
{
    public class AdRejected : IEvent
    {
        public Guid AdId { get; }

        public AdRejected(Guid adId)
        {
            AdId = adId;
        }
    }
}