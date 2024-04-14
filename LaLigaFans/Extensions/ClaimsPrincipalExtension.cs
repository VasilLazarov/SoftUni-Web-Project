using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LaLigaFans.Infrastructure.Constants.AdminConstants;

namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }

        public static bool IsPublisher(this ClaimsPrincipal user)
        {
            return user.IsInRole("Publisher");
        }

    }
}
