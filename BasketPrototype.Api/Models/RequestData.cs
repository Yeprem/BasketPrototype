using System;

namespace BasketPrototype.Api.Models
{
    public class RequestData
    {
        public Guid BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
