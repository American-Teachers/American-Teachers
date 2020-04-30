using System.Threading.Tasks;

namespace AtApi.Service.Authorization
{
    public interface IJwtTokenManager
    {
        Task<string> GenerateTokenAsync(string googleToken);
        bool ValidateToken(string token);
    }
}
