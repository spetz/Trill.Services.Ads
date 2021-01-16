using System;

namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class InvalidPeriodException : DomainException
    {
        public DateTime From { get; }
        public DateTime To { get; }

        public InvalidPeriodException(DateTime from, DateTime to) : base($"Invalid period: '{from}' - '{to}'.")
        {
            From = from;
            To = to;
        }
    }
}