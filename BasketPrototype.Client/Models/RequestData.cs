using Newtonsoft.Json;
using System;

namespace BasketPrototype.Client.Models
{
    public class RequestData
    {
        [JsonProperty(PropertyName = "basketId")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "productId")]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
