namespace Trill.Services.Ads.Core.Domain.Exceptions
{
    public class InvalidContentException : DomainException
    {
        public InvalidContentException() : base("Invalid content.")
        {
        }
    }
}