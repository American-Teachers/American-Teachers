using AtApi.Service.Framework;
using AtApi.Service.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AtApi.Service.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        {
            await Task.Delay(1);
            return await _userManager.FindByEmailAsync(payload.Email);
        }

        public async Task<ApplicationUser> ValidateAsync(string tokenId)
        {
            Guard.IsNotNull(() => tokenId);
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, new GoogleJsonWebSignature.ValidationSettings());
            return await Authenticate(payload);
        }

        public async Task<ApplicationUser> ValidateAsync(ClaimsPrincipal user)
        {
            var googleKey = user.Claims.FirstOrDefault(c => c.Type == Claims.GoogleToken)?.Value;
            return await ValidateAsync(googleKey);
        }
    }
}
