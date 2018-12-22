using BasketPrototype.Client.Configuration;
using System.Configuration;

namespace BasketPrototype.Console.Configuration
{
    public class Configuration : IConfiguration
    {
        public string Url => ConfigurationManager.AppSettings["ApiUrl"];
    }
}
