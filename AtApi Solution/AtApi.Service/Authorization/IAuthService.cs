using AtApi.Service.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AtApi.Service.Authorization
{
    public interface IAuthService
    {
        Task<ApplicationUser> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
        Task<ApplicationUser> ValidateAsync(string tokenId);
        Task<ApplicationUser> ValidateAsync(ClaimsPrincipal user);
    }
}
