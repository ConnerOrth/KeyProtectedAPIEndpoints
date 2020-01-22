using KeyProtectedAPIEndpoints.AuthenticationHandlers.APIKeys;
using Microsoft.AspNetCore.Authorization;

namespace KeyProtectedAPIEndpoints.AuthorizationHandlers
{
    public class APIKeyRequirement : IAuthorizationRequirement
    {
        public string AuthenticationType { get; }

        public APIKeyRequirement() : this(new APIKeyAuthenticationOptions()) { }

        public APIKeyRequirement(APIKeyAuthenticationOptions options)
        {
            options ??= new APIKeyAuthenticationOptions();
            AuthenticationType = options.AuthenticationType;
        }
    }
}
