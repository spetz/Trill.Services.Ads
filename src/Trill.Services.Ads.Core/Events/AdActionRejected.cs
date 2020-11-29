using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core.Events
{
    public class AdActionRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public AdActionRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}