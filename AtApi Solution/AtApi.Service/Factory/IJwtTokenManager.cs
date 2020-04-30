namespace AtApi.Service.Factory
{
    public interface IJwtTokenManager
    {
        string GenerateToken();
        bool ValidateToken(string token);
    }
}
