using System;
using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core.Events
{
    public class AdCreated : IEvent
    {
        public Guid AdId { get; }

        public AdCreated(Guid adId)
        {
            AdId = adId;
        }
    }
}