using System;
using System.Collections.Generic;

namespace BasketPrototype.Service.Models
{
    public interface IBasket
    {
        Guid BasketId { get; }
        IList<BasketItem> Items { get; }
    }

    public class Basket : IBasket
    {
        public Guid BasketId { get; set; }
        public IList<BasketItem> Items { get; set; }
    }

    public class BasketItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
