using BasketPrototype.Service.Models;
using System;
using System.Collections.Generic;

namespace BasketPrototype.Service.Services
{
    public interface IDataStore
    {
        IList<BasketItem> GetOrCreate(Guid basketId);
    }
}
