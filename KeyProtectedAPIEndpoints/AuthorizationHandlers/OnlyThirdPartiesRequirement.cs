using Microsoft.AspNetCore.Authorization;

namespace KeyProtectedAPIEndpoints.AuthorizationHandlers
{
    public class OnlyThirdPartiesRequirement : IAuthorizationRequirement
    {
    }
}
