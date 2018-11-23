using System;
using BasketPrototype.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketPrototype.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Add([FromBody] Guid basketId, [FromBody] int productId, [FromBody] int quantity)
        {
            var result = _basketService.TryAddItem(basketId, productId, quantity);
            return result ? Ok() : StatusCode(417);
        }

        // PUT api/values/5
        [HttpPut("{basketId}")]
        public IActionResult Update(Guid basketId, [FromBody] int productId, [FromBody] int quantity)
        {
            var result = _basketService.TryUpdateItem(basketId, productId, quantity);
            return result ? Ok() : StatusCode(417);
        }

        [HttpPut("{basketId}")]
        public IActionResult Remove(Guid basketId, [FromBody] int productId)
        {
            var result = _basketService.TryRemoveItem(basketId, productId);
            return result ? Ok() : StatusCode(417);
        }

        // DELETE api/values/5
        [HttpDelete("{basketId}")]
        public IActionResult Clear(Guid basketId)
        {
            var result = _basketService.TryClearBasket(basketId);
            return result ? Ok() : StatusCode(417);
        }
    }
}
