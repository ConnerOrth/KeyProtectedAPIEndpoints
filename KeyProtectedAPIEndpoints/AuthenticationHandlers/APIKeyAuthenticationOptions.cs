#nullable enable
using Microsoft.AspNetCore.Authentication;

namespace KeyProtectedAPIEndpoints.AuthenticationHandlers.APIKeys
{
    public class APIKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string AuthenticationScheme { get; set; } = APIKeyAuthenticationDefaults.AuthenticationScheme;
        public string AuthenticationType { get; set; } = APIKeyAuthenticationDefaults.AuthenticationScheme;
        public string HeaderName { get; set; } = APIKeyAuthenticationDefaults.HeaderName;
    }
}
#nullable disable
