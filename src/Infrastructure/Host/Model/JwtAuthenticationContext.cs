using Infrastructure.Model;

namespace Infrastructure.Host
{
    public class JwtAuthenticationContext : JwtAuthenticationBaseContext
    {
        public Environment Environment { get; set; }
    }
}