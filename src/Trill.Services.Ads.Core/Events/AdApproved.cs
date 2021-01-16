using System;
using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core.Events
{
    public class AdApproved : IEvent
    {
        public Guid AdId { get; }

        public AdApproved(Guid adId)
        {
            AdId = adId;
        }
    }
}