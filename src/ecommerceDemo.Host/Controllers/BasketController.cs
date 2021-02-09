using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using ecommerceDemo.Service;
using Infrastructure.Service.Model;
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
        private readonly ILogger<AuthenticationController> _logger;

        public BasketController(IAuthenticationService authenticationService, IBasketService basketService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _basketService = basketService;
            _logger = logger;
        }

        [HttpPost]
        [AddToBasketRequestValidator]
        public async Task<IActionResult> AddToBasket([FromBody] AddToBasketRequest request)
            => Ok(await _basketService.AddToBasket(new AddToBasketContext { BasketId = request.BasketId, ProductId = request.ProductId }));
    }
}