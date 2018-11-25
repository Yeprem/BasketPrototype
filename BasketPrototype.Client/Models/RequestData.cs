using System;

namespace BasketPrototype.Client.Models
{
    public class RequestData
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
