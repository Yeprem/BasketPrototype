using BasketPrototype.Client.Models;
using System.Threading.Tasks;

namespace BasketPrototype.Client.Services
{
    public interface IHttpRequestHandler
    {
        Task<ResponseData<T>> Get<T>(string endpoint, RequestData data);
        Task Post(string endpoint, RequestData data);
        Task Put(string endpoint, RequestData data);
        Task Delete(string endpoint, RequestData data);
    }
}
