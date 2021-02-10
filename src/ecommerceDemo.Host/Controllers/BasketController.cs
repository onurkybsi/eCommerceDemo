using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using ecommerceDemo.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ecommerceDemo.Host.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IBasketService _basketService;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IAuthenticationService authenticationService, IBasketService basketService, ILogger<BasketController> logger)
        {
            _authenticationService = authenticationService;
            _basketService = basketService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket()
            => Ok(await _basketService.CreateNewBasket());

        [HttpPost]
        [AddProductToBasketValidator]
        public async Task<IActionResult> AddProductToBasket([FromBody] AddProductToBasketRequest request)
        {
            var response = await _basketService.AddProductToBasket(new AddProductToBasketContext { BasketId = request.BasketId, ProductId = request.ProductId });

            if (response.IsSuccessful)
                _logger.LogInformation($"Product {request.ProductId} added to basket {request.BasketId}");

            return Ok(response);
        }
    }
}