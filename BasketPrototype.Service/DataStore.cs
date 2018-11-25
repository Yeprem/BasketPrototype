using BasketPrototype.Service.Models;
using BasketPrototype.Service.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BasketPrototype.Service
{
    public class DataStore : IDataStore
    {
        private readonly IDictionary<Guid, Basket> _store;

        public DataStore()
        {
            _store = new ConcurrentDictionary<Guid, Basket>();
        }

        public Basket GetOrCreate(Guid basketId)
        {
            Basket result = null;

            if (_store.TryGetValue(basketId, out Basket value))
            {
                result = value;
            }
            else
            {
                result = new Basket { BasketId = basketId, Items = new List<BasketItem>() };
                _store.Add(basketId, result);
            }

            return result;
        }
    }
}
