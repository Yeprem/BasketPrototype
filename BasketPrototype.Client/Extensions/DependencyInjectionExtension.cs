using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BasketPrototype.Client.Services;
using BasketPrototype.v1.Client;

namespace BasketPrototype.Client.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void InjectDependencies(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddSingleton<IBasketServiceClient, BasketServiceClient>()
                .AddSingleton<IHttpRequestHandler, HttpRequestHandler>();
        }
    }
}
