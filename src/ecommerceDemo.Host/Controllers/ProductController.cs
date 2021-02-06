using ecommerceDemo.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceDemo.Host.Controllers
{
    // [Authorize]
    // [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(IProductRepository productRepository)
        {
            return Ok(_productRepository.GetList());
        }
    }
}