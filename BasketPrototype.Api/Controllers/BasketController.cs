using System;
using BasketPrototype.Api.Models;
using BasketPrototype.Service.Models;
using BasketPrototype.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketPrototype.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{basketId}")]
        public ActionResult<Basket> Get(Guid basketId)
        {
            var result = _basketService.GetOrCreateBasket(basketId);
            return Ok(result);
        }

        // POST api/v1/values
        [HttpPost]
        public IActionResult Add([FromBody] RequestData data)
        {
            var result = _basketService.TryAddItem(data.BasketId, data.ProductId, data.Quantity);
            return result ? Ok() : StatusCode(417);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Update([FromBody] RequestData data)
        {
            var result = _basketService.TryUpdateItem(data.BasketId, data.ProductId, data.Quantity);
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
