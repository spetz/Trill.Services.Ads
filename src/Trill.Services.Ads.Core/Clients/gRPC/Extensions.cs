using System;
using System.Net.Http;
using Convey;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Trill.Services.Ads.Core.Clients.gRPC
{
    internal static class Extensions
    {
        public static IConveyBuilder AddGrpc(this IConveyBuilder builder)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var options = builder.GetOptions<GrpcOptions>("grpc");
            builder.Services
                .AddSingleton(options)
                .AddSingleton<IStoryApiClient, StoryApiGrpcClient>()
                .AddSingleton(services =>
                {
                    var url = options.Services["stories"];
                    return GrpcChannel.ForAddress(url, new GrpcChannelOptions
                    {
                        HttpClient = new HttpClient(new HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback =
                                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                        })
                    });
                });

            return builder;
        }
    }
}