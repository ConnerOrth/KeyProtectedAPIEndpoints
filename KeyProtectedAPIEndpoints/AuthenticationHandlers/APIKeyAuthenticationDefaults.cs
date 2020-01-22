namespace KeyProtectedAPIEndpoints.AuthenticationHandlers.APIKeys
{
    /// <summary>
    /// Default values used by API Key authentication.
    /// </summary>
    public static class APIKeyAuthenticationDefaults
    {
        /// <summary>
        /// Default value for AuthenticationScheme/Type property in the <see cref="APIKeyAuthenticationOptions"/>
        /// </summary>
        public const string AuthenticationScheme = "API Key";

        /// <summary>
        /// Default value for HeaderName property in the <see cref="APIKeyAuthenticationOptions"/>
        /// </summary>
        public const string HeaderName = "X-API-KEY";
    }
}
