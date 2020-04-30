using AtApi.Models.TokenViewModels;
using AtApi.Service.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
namespace AtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    [Produces("application/json")] 
    [ApiVersionNeutral]

    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;

        public TokenController(IJwtTokenManager jwtTokenService)
        {
            _jwtTokenManager = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        }

        /// <summary>
        /// Generate sample token
        /// </summary>       
        /// <returns>Generated token</returns>        
        [AllowAnonymous]
        [HttpGet("generate")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Generated token")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public ActionResult<GenerateTokenResponse> GenerateToken()
        {
            var token = _jwtTokenManager.GenerateToken();
            return Ok(new GenerateTokenResponse { Bearer = token });
        }

        /// <summary>
        /// Validate sample token
        /// </summary>
        /// <param name="token">Token for validation</param>
        /// <returns>Token validation status</returns>        
        [HttpPost("validate")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Token validation status")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad request for missing or invalid parameter")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public IActionResult ValidateToken([FromBody] string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            var isValid = _jwtTokenManager.ValidateToken(token);

            return Ok(new { isValid });
        }
    }
}