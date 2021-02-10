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
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        [CreateNewProductRequestValidator]
        public async Task<IActionResult> CreateNewProduct([FromBody] CreateNewProductRequest request)
        {
            var response = await _productService.CreateProduct(new CreateProductContext
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                CategoryName = request.CategoryName
            });

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
            => Ok(await _productService.GetAllProducts());
    }
}