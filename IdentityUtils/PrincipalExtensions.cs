using System.Linq;
using System.Security.Principal;

namespace MudBlazorServerId.IdentityUtils
{
    public static class PrincipalExtensions
    {
        public static bool IsInAllRoles(this IPrincipal principal, params string[] roles)
        {
            return roles.All(r1 => r1.Split(',').All(r2 => principal.IsInRole(r2.Trim())));
        }

        public static bool IsInAnyRoles(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(r1 => r1.Split(',').Any(r2 => principal.IsInRole(r2.Trim())));
        }
    }
}