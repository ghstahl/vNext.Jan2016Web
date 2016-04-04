﻿namespace Web.IdentityServer4.Host.IdentityServerClients.Configuration
{
    public static class Constants
    {
        public const string BaseAddress = "http://localhost:14010";

        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public const string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";
        public const string IntrospectionEndpoint = BaseAddress + "/connect/introspect";

        public const string AspNetWebApiSampleApi = "http://localhost:14016/";
    }
}
