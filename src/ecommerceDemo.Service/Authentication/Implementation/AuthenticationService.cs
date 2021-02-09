using Infrastructure.Service;

namespace ecommerceDemo.Service
{
    public class AuthenticationService : Infrastructure.Service.JwtAuthenticationService, IAuthenticationService
    {
        public AuthenticationService(JwtAuthenticationContext context) : base(context) { }
    }
}