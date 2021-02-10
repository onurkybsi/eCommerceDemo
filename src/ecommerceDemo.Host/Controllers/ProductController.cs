using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using ecommerceDemo.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ecommerceDemo.Host.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = Infrastructure.Service.Constants.JwtAuthenticationService.UserRole.Admin)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<AuthenticationController> _logger;

        public ProductController(IProductService productService, ILogger<AuthenticationController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        [CreateNewProductRequestValidator]
        public async Task<IActionResult> CreateNewProduct([FromBody] CreateNewProductRequest request)
        {
            

            return Ok();
        }

        [HttpGet]
        [AddProductToBasketValidator]
        public async Task<IActionResult> GetAllProducts()
        {
            

            return Ok();
        }
    }
}