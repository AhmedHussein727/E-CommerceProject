using ECommerce.services_Abstraction;
using ECommerce.Shared;
using ECommerce.Shared.DTos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presintation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<productDTO>>> GetAllProducts([FromQuery]ProductQueryParams queryParams)
        {
            var products = await productService.GetAllProductsAsync(queryParams);
            return Ok(products);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands=await productService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult< IEnumerable<TypeDto>>> GetAllTypes()
        {
            var types=await productService.GetAllTypesAsync();
            return Ok(types);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<productDTO>> getProductById(int id)
        {
            var product=await productService.GetProductByIDAsync(id);
            return Ok(product);
        }

    }
}
