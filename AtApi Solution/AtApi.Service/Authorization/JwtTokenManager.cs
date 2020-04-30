using AtApi.Model.Settings;
using AtApi.Service.Framework;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AtApi.Service.Authorization
{
    class JwtTokenManager : IJwtTokenManager
    {
        private readonly IOptionsMonitor<AppSettings> _options;
        private readonly ISecurity _security;
        private readonly IAuthService _authService;

        public JwtTokenManager(IOptionsMonitor<AppSettings> options, ISecurity security, IAuthService authService)
        {
            _options = options;
            _security = security;
            _authService = authService;
        }
        public async Task<string> GenerateTokenAsync(string googleToken)
        {
            var nowDT = DateTime.UtcNow;
            var key = Encoding.ASCII.GetBytes(_options.CurrentValue.JwtSecretKey);
            var user = await _authService.ValidateAsync(googleToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = nowDT,
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("dt", nowDT.ToString("yyyy-MM-ddTHH:mm:ssK")),
                        new Claim(Claims.GoogleToken, googleToken),
                        new Claim(JwtRegisteredClaimNames.Sub, _security.Encrypt(_options.CurrentValue.JwtEmailEncryption ,user.Email)),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = nowDT.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var finalToken = tokenHandler.WriteToken(token);

            return finalToken;
        }

        public bool ValidateToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.CurrentValue.JwtSecretKey))
            };

            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
