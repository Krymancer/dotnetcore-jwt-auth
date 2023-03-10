namespace Application.Configuration
{
    public class JwtConfiguration
    {
        public string Secret { get; set; } = String.Empty;
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;    
    }
}
