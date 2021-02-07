using System.Threading.Tasks;
using Infrastructure.Service.Model;

namespace ecommerceDemo.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Authenticate(SignInModel signInModel);
    }
}