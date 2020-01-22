using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace KeyProtectedAPIEndpoints.AuthorizationHandlers
{
    public class APIKeyAuthorizationHandler : AuthorizationHandler<APIKeyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, APIKeyRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
            }

            if (context.User.Identity.AuthenticationType == requirement.AuthenticationType)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
