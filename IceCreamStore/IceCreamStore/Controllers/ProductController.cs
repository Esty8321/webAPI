using AutoMapper;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IceCreamStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<ProductDTO>> Get()
        {
            return await _productService.GetAllProducts();
        }

        public async Task<ActionResult<IEnumerable<List<Product>>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice,
           [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds, int position = 1, int skip = 10)
        {
            var productDTOs = await _productService.GetProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
            //use shorted syntax 
            //return productDTOs == null ? BadRequest() : Ok(productDTOs);
            if (productDTOs == null)
            {
                return BadRequest();

            }
            return Ok(productDTOs);
        }
        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
