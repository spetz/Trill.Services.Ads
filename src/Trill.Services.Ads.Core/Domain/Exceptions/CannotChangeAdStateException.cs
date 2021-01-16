using System;

namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class CannotChangeAdStateException : DomainException
    {
        public Guid AdId { get; }

        public CannotChangeAdStateException(Guid adId) : base($"Ad with ID: '{adId}' state cannot be changed.")
        {
            AdId = adId;
        }
    }
}