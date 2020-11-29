using System;
using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core.Events
{
    public class AdPaid : IEvent
    {
        public Guid AdId { get; }

        public AdPaid(Guid adId)
        {
            AdId = adId;
        }
    }
}