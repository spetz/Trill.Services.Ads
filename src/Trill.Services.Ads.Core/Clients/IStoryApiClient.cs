using System.Threading.Tasks;
using Trill.Services.Ads.Core.Clients.Requests;

namespace Trill.Services.Ads.Core.Clients
{
    public interface IStoryApiClient
    {
        Task<long?> SendStoryAsync(SendStoryRequest request);
    }
}