using System.Threading.Tasks;
using Infrastructure.Service.Model;

namespace ecommerceDemo.Service
{
    public class AuthenticationService : Infrastructure.Service.JwtAuthenticationService, IAuthenticationService
    {
        public AuthenticationService(JwtAuthenticationContext context) : base(context) { }
    }
}