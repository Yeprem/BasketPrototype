using BasketPrototype.Client.Models;
using System;
using System.Threading.Tasks;

namespace BasketPrototype.Client.Services
{
    public interface IBasketServiceClient
    {
        Task<Basket> GetOrCreateBasket(Guid basketId);
        Task<bool> AddItem(Guid basketId, int productId, int quantity);
        Task<bool> UpdateItem(Guid basketId, int productId, int quantity);
        Task<bool> RemoveItem(Guid basketId, int productId);
        Task<bool> ClearBasket(Guid basketId);
    }
}
