using System;

namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class CannotPayAdException : DomainException
    {
        public Guid AdId { get; }

        public CannotPayAdException(Guid adId) : base($"Ad with ID: '{adId}' cannot be paid.")
        {
            AdId = adId;
        }
    }
}