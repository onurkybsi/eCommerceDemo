namespace Infrastructure.Host.Model
{
    public class JwtAuthenticationContext : JwtAuthenticationBaseContext
    {
        public Environment Environment { get; set; }
    }
}