using BasketPrototype.Service.Models;
using System;

namespace BasketPrototype.Service.Services
{
    public interface IBasketService
    {
        IBasket GetOrCreateBasket(Guid basketId);
        bool TryAddItem(Guid basketId, int productId, int quantity);
        bool TryUpdateItem(Guid basketId, int productId, int quantity);
        bool TryClearBasket(Guid basketId);
    }
}
