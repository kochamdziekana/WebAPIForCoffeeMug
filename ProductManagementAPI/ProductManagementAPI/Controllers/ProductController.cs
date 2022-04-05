using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts() {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductById(Guid id) {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Guid> AddProduct([FromBody] NewProductDto dto) {
            return Ok();
        } 
    
        [HttpPut]
        public ActionResult UpdateProduct([FromBody] UpdateProductDto dto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromBody] Guid id)
        {
            return NotFound();
        }
    }
}
