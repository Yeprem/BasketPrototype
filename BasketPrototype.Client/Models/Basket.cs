using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BasketPrototype.Client.Models
{
    [Serializable]
    public class BasketItem
    {
        [JsonProperty(PropertyName = "productId")]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }

    [Serializable]
    public class Basket
    {
        [JsonProperty(PropertyName = "basketId")]
        public Guid BasketId { get; set; }
        [JsonProperty(PropertyName = "items")]
        public List<BasketItem> Items { get; set; }
    }
}
