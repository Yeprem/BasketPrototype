using System.Net.Http;

namespace BasketPrototype.Client.Models
{
    public class ResponseData<T>
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public T Payload { get; set; }
    }
}
