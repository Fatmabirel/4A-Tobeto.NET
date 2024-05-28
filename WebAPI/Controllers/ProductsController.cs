using Business.Abstracts;
using Business.Concretes;
using Business.Dtos.Product;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService productService; // ❌❌❌

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductForListingDto>> GetAll()
        {
            return await productService.GetAll();
        }

        [HttpPost]
        public async Task Add([FromBody] ProductForAddDto product)
        {
            await productService.Add(product);
        }


    }
}