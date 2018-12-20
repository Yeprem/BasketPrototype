using BasketPrototype.Client.Extensions;
using BasketPrototype.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketPrototype.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .InjectDependencies()
                .BuildServiceProvider();

            System.Console.WriteLine("Starting Test");      

            var client = serviceProvider.GetService<IBasketServiceClient>();
            var basketId = Guid.NewGuid();

            System.Console.WriteLine("Creating Basket");
            var response = client.GetOrCreateBasket(basketId).Result;

            if (response != null)
            {
                System.Console.WriteLine("Creating Basket - Id: {0}, Items : {1}", response.BasketId, GetItems(response.Items));
            }
            else
            {
                System.Console.WriteLine("Creating Basket - false");
            }            

            System.Console.WriteLine("Adding Item 1");
            var response2 = client.AddItem(basketId, 1, 1).Result;
            System.Console.WriteLine("Adding Item 1 - {0}", response2);

            response = client.GetOrCreateBasket(basketId).Result;
            System.Console.WriteLine("Get Basket - Id: {0}, Items : {1}", response.BasketId, GetItems(response.Items));

            System.Console.WriteLine("Adding Item 2");
            var response3 = client.AddItem(basketId, 2, 1).Result;
            System.Console.WriteLine("Adding Item 2 - {0}", response3);

            response = client.GetOrCreateBasket(basketId).Result;
            System.Console.WriteLine("Get Basket - Id: {0}, Items : {1}", response.BasketId, GetItems(response.Items));

            System.Console.WriteLine("Updating Item 1 Qty to 2");
            var response4 = client.UpdateItem(basketId, 1, 2).Result;
            System.Console.WriteLine("Updating Item 1 Qty to 2 - {0}", response4);

            response = client.GetOrCreateBasket(basketId).Result;
            System.Console.WriteLine("Get Basket - Id: {0}, Items : {1}", response.BasketId, GetItems(response.Items));

            System.Console.WriteLine("Removing Item 2");
            var response5 = client.RemoveItem(basketId, 2).Result;
            System.Console.WriteLine("Removing Item 2 - {0}", response5);

            response = client.GetOrCreateBasket(basketId).Result;
            System.Console.WriteLine("Get Basket - Id: {0}, Items : {1}", response.BasketId, GetItems(response.Items));

            System.Console.WriteLine("Clear Basket");
            var response6 = client.ClearBasket(basketId).Result;
            System.Console.WriteLine("Clear Basket - {0}", response6);

            response = client.GetOrCreateBasket(basketId).Result;
            System.Console.WriteLine("Creating Basket - Id: {0}, Items : {1}", response.BasketId, GetItems(response.Items));

            System.Console.ReadLine();
        }

        private static string GetItems(IEnumerable<Client.Models.BasketItem> items)
        {
            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.Append($"Item Id : {item.ProductId} Qty : {item.Quantity} | ");
            }

            return sb.ToString();
        }
    }
}
