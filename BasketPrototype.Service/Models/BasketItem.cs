using System;
using System.Collections.Generic;

namespace BasketPrototype.Service.Models
{
    public interface IBasket
    {
        Guid Id { get; }
        IList<BasketItem> Items { get; }
    }

    public class Basket : IBasket
    {
        public Guid Id { get; set; }
        public IList<BasketItem> Items { get; set; }
    }

    public class BasketItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
