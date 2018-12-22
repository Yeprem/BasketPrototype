using BasketPrototype.Service.Models;
using System;

namespace BasketPrototype.Service.Services
{
    /*
        This interface needs to be registered as singleton. 
    */

    public interface IDataStore
    {
        IBasket GetOrCreate(Guid basketId);
    }
}
