using System;
using System.Collections.Generic;

namespace BasketPrototype.Client.Models
{
    public interface IBasket
    {
        Guid Id { get; }
        IEnumerable<IBasketItem> Items { get; }
    }

    public interface IBasketItem
    {
        int ProductId { get; }
        int Quantity { get; }
    }

    [Serializable]
    public class Basket : IBasket
    {
        public Guid Id { get; set; }

        public IEnumerable<IBasketItem> Items { get; set; }
    }
}
