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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
            => Ok(await _categoryService.GetAllCategories());

        [HttpPost]
        [CreateCategoryRequestValidator]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var response = await _categoryService.CreateCategory(new CreateCategoryContext
            {
                Name = request.Name
            });

            return Ok(response);
        }
    }
}