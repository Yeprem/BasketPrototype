using BasketPrototype.Client.Models;
using BasketPrototype.Client.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BasketPrototype.v1.Client
{
    public class BasketServiceClient : IBasketServiceClient
    {
        private readonly IHttpRequestHandler _requestHandler;
        private readonly ILogger<BasketServiceClient> _logger;
        private readonly string _endpoint = "https://localhost:44366/api/v1/basket/";

        public BasketServiceClient(IHttpRequestHandler requestHandler, ILogger<BasketServiceClient> logger)
        {
            _requestHandler = requestHandler;
            _logger = logger;
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
                _logger.LogError(ex, "An error occured while adding item to the basket");
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
                _logger.LogError(ex, "An error occured while clearing the basket");
            }

            return result;
        }

        public async Task<Basket> GetOrCreateBasket(Guid basketId)
        {
            Basket result = null;

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
                _logger.LogError(ex, "An error occured while getting the basket");
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
                _logger.LogError(ex, "An error occured while removing the basket"); 
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
                _logger.LogError(ex, "An error occured while updating the basket");
            }

            return result;
        }
    }
}
