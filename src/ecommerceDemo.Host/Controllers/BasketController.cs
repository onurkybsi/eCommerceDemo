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
        private readonly IUserService _userService;
        private readonly ILogger<AuthenticationController> _logger;

        public BasketController(IAuthenticationService authenticationService, IUserService userService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [AddToBasketRequestValidator]
        public async Task<IActionResult> AddToBasket([FromBody] AddToBasketRequest request)
        {
            // TO-DO

            return Ok();
        }
    }
}