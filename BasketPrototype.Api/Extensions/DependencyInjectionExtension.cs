using BasketPrototype.Service;
using BasketPrototype.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasketPrototype.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void InjectDependencies(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddSingleton<IDataStore, DataStore>()
                .AddSingleton<IBasketService, BasketService>();
        }
    }
}
