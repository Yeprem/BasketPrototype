using Microsoft.Extensions.DependencyInjection;
using BasketPrototype.Client.Services;
using BasketPrototype.v1.Client;

namespace BasketPrototype.Client.Extensions
{
    public static class DependencyInjectionExtension
    {
        /*
            This extension method is used to keep service registrations in one place
        */

        public static IServiceCollection InjectDependencies<T>(this IServiceCollection collection) where T : class, Configuration.IConfiguration
        {
            collection.AddSingleton<IBasketServiceClient, BasketServiceClient>()
                .AddSingleton<IHttpRequestHandler, HttpRequestHandler>()
                .AddSingleton<Configuration.IConfiguration, T>()
                .AddLogging();

            return collection;
        }
    }
}
