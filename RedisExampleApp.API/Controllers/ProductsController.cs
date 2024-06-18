using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedisEcampleApp.Cache;
using RedisExampleApp.API.Models;
using RedisExampleApp.API.Repositories;
using RedisExampleApp.API.Services;
using StackExchange.Redis;

namespace RedisExampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

       

       public ProductsController(IProductService productRepository)
        {
            _productService = productRepository;
     
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _productService.GetAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            return Created(string.Empty, await _productService.CreateAsync(product));
        }
    }
}
