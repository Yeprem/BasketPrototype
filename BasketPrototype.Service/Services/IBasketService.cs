using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPrototype.Service.Services
{
    public interface IBasketService
    {
        bool TryAddItem(Guid basketId, int productId, int quantity);
        bool TryUpdateItem(Guid basketId, int productId, int quantity);
        bool TryRemoveItem(Guid basketId, int productId);
        bool TryClearBasket(Guid basketId);
    }
}
