using irem_proje.application.Services.Base;
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
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;
        public ProductController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _repository.GetProducts();
            return Ok(products);
        }

    }
}
