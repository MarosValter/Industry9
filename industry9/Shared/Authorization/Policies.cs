using industry9.Shared.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace industry9.Shared.Authorization
{
    public static class Policies
    {
        public const string IsAdmin = "IsAdmin";
        public const string IsUser = "IsUser";
        public const string IsReadOnly = "IsReadOnly";
        public const string IsMyDomain = "IsMyDomain";

        public static AuthorizationPolicy IsAdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("IsAdministrator")
                .Build();
        }

        public static AuthorizationPolicy IsUserPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("IsUser")
                .Build();
        }

        public static AuthorizationPolicy IsReadOnlyPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("ReadOnly", "true")
                .Build();
        }

        public static AuthorizationPolicy IsMyDomainPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddRequirements(new DomainRequirement("blazorboilerplate.com"))
                .Build();
        }
    }
}
