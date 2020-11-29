using System.Threading.Tasks;
using Trill.Services.Ads.Core.Clients.Requests;

namespace Trill.Services.Ads.Core.Clients.gRPC
{
    internal class StoryApiGrpcClient : IStoryApiClient
    {
        public async Task<long?> SendStoryAsync(SendStoryRequest request)
        {
            await Task.CompletedTask;
            return default;
        }
    }
}