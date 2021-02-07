using System.Threading.Tasks;
using ecommerceDemo.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceDemo.Host.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productRepository.GetList());
        }
    }
}