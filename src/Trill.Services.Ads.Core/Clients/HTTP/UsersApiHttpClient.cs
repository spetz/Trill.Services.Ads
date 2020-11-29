using System;
using System.Threading.Tasks;
using Convey.HTTP;

namespace Trill.Services.Ads.Core.Clients.HTTP
{
    internal sealed class UsersApiHttpClient : IUsersApiClient
    {
        private readonly IHttpClient _client;
        private readonly string _url;

        public UsersApiHttpClient(IHttpClient client, HttpClientOptions options)
        {
            _client = client;
            _url = options.Services["users"];
        }

        public async Task<bool> ChargeFundsAsync(Guid userId, decimal amount)
        {
            var response = await _client.PostAsync($"{_url}/users/{userId}/funds/charge", new
            {
                userId, amount
            });

            return response.IsSuccessStatusCode;
        }
    }
}