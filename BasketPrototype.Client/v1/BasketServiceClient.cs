using BasketPrototype.Client.Models;
using BasketPrototype.Client.Services;
using System;
using System.Threading.Tasks;

namespace BasketPrototype.v1.Client
{
    public class BasketServiceClient : IBasketServiceClient
    {
        private readonly IHttpRequestHandler _requestHandler;
        private readonly string _endpoint = "api/v1/basket";

        public BasketServiceClient(IHttpRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public async Task<bool> AddItem(Guid basketId, int productId, int quantity)
        {
            var result = false;

            try
            {
                await _requestHandler.Post($"{_endpoint}", new RequestData { Id = basketId, ProductId = productId, Quantity = quantity });
                result = true;
            }
            catch (Exception ex)
            {
                //log exception
            }

            return result;
        }

        public async Task<bool> ClearBasket(Guid basketId)
        {
            var result = false;

            try
            {
                await _requestHandler.Delete($"{_endpoint}", new RequestData { Id = basketId });
                result = true;
            }
            catch (Exception ex)
            {
                //log exception
            }

            return result;
        }

        public async Task<IBasket> GetOrCreateBasket(Guid basketId)
        {
            IBasket result = null;

            try
            {
                var response = await _requestHandler.Get<Basket>(_endpoint, new RequestData { Id = basketId });

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    result = response.Payload;
                }                
            }
            catch (Exception ex)
            {
                //log exception
            }

            return result;
        }

        public async Task<bool> RemoveItem(Guid basketId, int productId)
        {
            var result = false;

            try
            {
                await _requestHandler.Put($"{_endpoint}", new RequestData { Id = basketId, ProductId = productId });
                result = true;
            }
            catch (Exception ex)
            {
                //log exception
            }

            return result;
        }

        public async Task<bool> UpdateItem(Guid basketId, int productId, int quantity)
        {
            var result = false;

            try
            {
                await _requestHandler.Put($"{_endpoint}", new RequestData { Id = basketId, ProductId = productId, Quantity = quantity });
                result = true;
            }
            catch (Exception ex)
            {
                //log exception
            }

            return result;
        }
    }
}
