using System;

namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class CannotCreateAdAException : DomainException
    {
        public Guid AdId { get; }

        public CannotCreateAdAException(Guid adId) : base($"Ad with ID: '{adId}' cannot be created.")
        {
            AdId = adId;
        }
    }
}