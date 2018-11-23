using BasketPrototype.Service.Models;
using BasketPrototype.Service.Services;
using System;
using System.Collections.Generic;

namespace BasketPrototype.Service
{
    public class DataStore : IDataStore
    {
        private readonly IDictionary<Guid, IList<BasketItem>> _store;

        public DataStore()
        {
            _store = new Dictionary<Guid, IList<BasketItem>>();
        }

        public IList<BasketItem> GetOrCreate(Guid basketId)
        {
            IList<BasketItem> result = null;

            if (_store.TryGetValue(basketId, out IList<BasketItem> value))
            {
                result = value;
            }
            else
            {
                result = new List<BasketItem>();
                _store[basketId] = result;
            }

            return result;
        }
    }
}
