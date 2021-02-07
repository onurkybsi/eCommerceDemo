using System;
using System.Threading.Tasks;

namespace Infrastructure.Service.Model
{
    public class JwtAuthenticationContext : JwtAuthenticationBaseContext
    {
        public Func<SignInModel, Task<IUser>> GetUserAction { get; set; }
    }
}