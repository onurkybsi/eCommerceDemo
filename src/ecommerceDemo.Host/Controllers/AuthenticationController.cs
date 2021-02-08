using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using ecommerceDemo.Service;
using Infrastructure.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ecommerceDemo.Host.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [SignInModelValidator]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel newUser)
        {
            string hashedPass = Infrastructure.Service.EncryptionHelper.CreateHashed(newUser.Password);

            var createdUser = new Data.Model.User
            {
                Email = newUser.Email,
                HashedPassword = hashedPass,
            };

            await _userService.CreateUser(createdUser);
            _logger.LogInformation($"{createdUser.Id}-{createdUser.Id} signed in as user!");

            return Ok();
        }

        [HttpPost]
        [SignUpModelValidator]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var signInResult = await _authenticationService.Authenticate(signInModel);

            if (signInResult.IsAuthenticated)
                _logger.LogInformation($"{signInModel.Email} loged in!");
            else
                _logger.LogInformation($"{signInModel.Email} could not login: {signInResult.Message}");

            return Ok(signInResult);
        }
    }
}