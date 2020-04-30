using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AtApi.Service.Authorization
{
    public class GoogleTokenClaimRequirement : AuthorizationHandler<GoogleTokenClaimRequirement>, IAuthorizationRequirement
    {
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GoogleTokenClaimRequirement requirement)
        {
            //not needed if only a RequireClaim is used
            if (context.User.HasClaim(c => c.Type == Claims.GoogleToken)){
                context.Succeed(requirement);                
            }
            return Task.CompletedTask;
        }
    }
}
