using BasketPrototype.Service.Models;
using System;

namespace BasketPrototype.Service.Services
{
    public interface IDataStore
    {
        IBasket GetOrCreate(Guid basketId);
    }
}
