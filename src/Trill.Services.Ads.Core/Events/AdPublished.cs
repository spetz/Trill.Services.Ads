using System;
using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core.Events
{
    public class AdPublished : IEvent
    {
        public Guid AdId { get; }

        public AdPublished(Guid adId)
        {
            AdId = adId;
        }
    }
}