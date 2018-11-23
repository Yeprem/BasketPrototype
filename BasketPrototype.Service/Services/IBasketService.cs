using BasketPrototype.Service.Models;
using System;
using System.Collections.Generic;

namespace BasketPrototype.Service.Services
{
    public interface IBasketService
    {
        IList<BasketItem> GetItems(Guid basketId);
        bool TryAddItem(Guid basketId, int productId, int quantity);
        bool TryUpdateItem(Guid basketId, int productId, int quantity);
        bool TryRemoveItem(Guid basketId, int productId);
        bool TryClearBasket(Guid basketId);
    }
}
