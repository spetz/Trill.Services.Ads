using System;
using System.Threading.Tasks;

namespace Trill.Services.Ads.Core.Domain
{
    public interface IAdRepository
    {
        Task<Ad> GetAsync(Guid id);
        Task AddAsync(Ad ad);
        Task UpdateAsync(Ad ad);
    }
}