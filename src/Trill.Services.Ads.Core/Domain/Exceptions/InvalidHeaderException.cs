namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class InvalidHeaderException : DomainException
    {
        public InvalidHeaderException() : base("Invalid title.")
        {
        }
    }
}