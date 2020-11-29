using System;

namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class CannotPublishAdAException : DomainException
    {
        public Guid AdId { get; }

        public CannotPublishAdAException(Guid adId) : base($"Ad with ID: '{adId}' cannot be published.")
        {
            AdId = adId;
        }
    }
}