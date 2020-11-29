using System;

namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class AdNotFoundException : DomainException
    {
        public Guid AdId { get; }

        public AdNotFoundException(Guid adId) : base($"Ad with ID: '{adId}' was not found.")
        {
            AdId = adId;
        }
    }
}