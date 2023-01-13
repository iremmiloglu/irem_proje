using irem_proje.application.Services.Base;
using irem_proje.domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace irem_proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private static List<string> _ids = new List<string>();

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }
        // GET api/<BasketController>/5
        [HttpGet]
        public IActionResult GetBasketIds()
        {
            return Ok(_ids);
        }

        // GET api/<BasketController>/5
        [HttpGet("{id}")]
        public IActionResult GetBasket(string id)
        {
            List<Basket> baskets = _repository.GetBaskets(id);
            if (baskets.Any())
            {
                return Ok(baskets);
            }
            return NotFound(id);
        }

        // POST api/<BasketController>
        [HttpPost]
        public IActionResult Post([FromBody] Basket value)
        {
            List<Basket> baskets = new List<Basket>();
            baskets.Add(value);
            string id = Guid.NewGuid().ToString();
            _ids.Add(id);
            bool result = _repository.SaveBasket(baskets, id);
            if (result)
            {
                return Ok();
            }
            return Problem();
        }
    }
}
