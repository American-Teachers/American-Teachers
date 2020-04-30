namespace AtApi.Model.Settings
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public AuthenticationSettings Authentication { get; set; }
        public string[] AllowedOrigins { get; set; }
        public string JwtSecretKey { get; set; }
    }
}
