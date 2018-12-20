using Microsoft.Extensions.DependencyInjection;
using BasketPrototype.Client.Services;
using BasketPrototype.v1.Client;

namespace BasketPrototype.Client.Extensions
{
    public static class DependencyInjectionExtension
    {
        /*
            This extension method used to keep service registrations in one place
        */

        public static IServiceCollection InjectDependencies(this IServiceCollection collection)
        {
            collection.AddSingleton<IBasketServiceClient, BasketServiceClient>()
                .AddSingleton<IHttpRequestHandler, HttpRequestHandler>()
                .AddLogging();

            return collection;
        }
    }
}
