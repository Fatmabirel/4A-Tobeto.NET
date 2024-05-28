using Business.Abstracts;
using Business.Concretes;
using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
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
        public async Task<List<ListProductResponse>> GetAll()
        {
            return await productService.GetAll();
        }

        [HttpPost]
        public async Task Add([FromBody] AddProductRequest product)
        {
            await productService.Add(product);
        }


    }
}