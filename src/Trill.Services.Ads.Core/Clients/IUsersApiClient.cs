using System;
using System.Threading.Tasks;

namespace Trill.Services.Ads.Core.Clients
{
    public interface IUsersApiClient
    {
        Task<bool> ChargeFundsAsync(Guid userId, decimal amount);
    }
}