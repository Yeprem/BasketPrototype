using BasketPrototype.Service.Models;
using BasketPrototype.Service.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public IList<BasketItem> GetItems(Guid basketId)
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
                basket.Add(new BasketItem { ProductId = productId, Quantity = quantity });
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
                basket.Clear();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while clearing the basket {basketId}");
            }

            return result;
        }

        public bool TryRemoveItem(Guid basketId, int productId)
        {
            var result = false;

            try
            {
                var basket = _dataStore.GetOrCreate(basketId);
                basket = basket.Where(x => x.ProductId != productId)
                    .ToList();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while removing item {productId} from the basket {basketId}");
            }

            return result;
        }

        public bool TryUpdateItem(Guid basketId, int productId, int quantity)
        {
            var result = false;

            try
            {
                var basket = _dataStore.GetOrCreate(basketId);
                var item = basket.FirstOrDefault(x => x.ProductId == productId);

                if (item != null)
                {
                    throw new NullReferenceException($"Item {productId} doesn't exist in basket {basketId}");
                }

                item.Quantity = quantity;
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
