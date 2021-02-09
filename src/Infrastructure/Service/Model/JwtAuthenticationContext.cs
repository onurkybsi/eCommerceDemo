using System;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace Infrastructure.Service
{
    public class JwtAuthenticationContext : JwtAuthenticationBaseContext
    {
        public Func<SignInModel, Task<IUser>> GetUserAction { get; set; }
    }
}