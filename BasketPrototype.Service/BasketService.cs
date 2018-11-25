using BasketPrototype.Service.Models;
using BasketPrototype.Service.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BasketPrototype.Service
{
    public class BasketService : IBasketService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IDataStore dataStore, ILogger<BasketService> logger)
        {
            _dataStore = dataStore;
            _logger = logger;
        }

        public IBasket GetOrCreateBasket(Guid basketId)
        {
            var result = _dataStore.GetOrCreate(basketId);
            return result;
        }

        public bool TryAddItem(Guid basketId, int productId, int quantity)
        {
            var result = false;

            try
            {
                var basket = _dataStore.GetOrCreate(basketId);
                basket.Items.Add(new BasketItem { ProductId = productId, Quantity = quantity });
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while adding item {productId} with quantity {quantity} to the basket {basketId}");
            }

            return result;
        }

        public bool TryClearBasket(Guid basketId)
        {
            var result = false;

            try
            {
                var basket = _dataStore.GetOrCreate(basketId);
                basket.Items.Clear();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while clearing the basket {basketId}");
            }

            return result;
        }

        public bool TryUpdateItem(Guid basketId, int productId, int quantity)
        {
            var result = false;

            try
            {
                var basket = _dataStore.GetOrCreate(basketId);
                var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);

                if (item == null)
                {
                    throw new NullReferenceException($"Item {productId} doesn't exist in basket {basketId}");
                }

                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    basket.Items.Remove(item);
                }
               
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while updating item {productId} with quantity {quantity} to the basket {basketId}");
            }

            return result;
        }
    }
}
