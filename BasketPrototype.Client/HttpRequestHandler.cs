using BasketPrototype.Client.Models;
using BasketPrototype.Client.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasketPrototype.Client
{
    public class HttpRequestHandler : IHttpRequestHandler
    {
        public async Task Delete(string endpoint, RequestData data)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{endpoint}/{data.Id}");
            }            
        }

        public async Task<ResponseData<T>> Get<T>(string endpoint, RequestData data)
        {
            var result = new ResponseData<T>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{endpoint}/{data.Id}");
                result.ResponseMessage = response;
                result.Payload = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        public async Task Post(string endpoint, RequestData data)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "basketId", data.Id.ToString() },
                   { "productId", data.ProductId.ToString() },
                   { "quantity", data.Quantity.ToString() }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(endpoint, content);
            }
        }

        public async Task Put(string endpoint, RequestData data)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "basketId", data.Id.ToString() },
                   { "productId", data.ProductId.ToString() },
                   { "quantity", data.Quantity.ToString() }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PutAsync(endpoint, content);
            }
        }
    }
}
