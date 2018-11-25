using BasketPrototype.Client.Models;
using BasketPrototype.Client.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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
                response.EnsureSuccessStatusCode();
            }            
        }

        public async Task<ResponseData<T>> Get<T>(string endpoint, RequestData data)
        {
            var result = new ResponseData<T>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{endpoint}/{data.Id}");
                response.EnsureSuccessStatusCode();
                result.ResponseMessage = response;
                result.Payload = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        public async Task Post(string endpoint, RequestData data)
        {
            using (var client = new HttpClient())
            {
                var seriazlizedObject = JsonConvert.SerializeObject(data);
                var content = new StringContent(seriazlizedObject, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task Put(string endpoint, RequestData data)
        {
            using (var client = new HttpClient())
            {
                var seriazlizedObject = JsonConvert.SerializeObject(data);
                var content = new StringContent(seriazlizedObject, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
