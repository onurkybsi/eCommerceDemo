namespace Infrastructure.Host
{
    public class JwtAuthenticationContext
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public Environment Environment { get; set; }
    }
}