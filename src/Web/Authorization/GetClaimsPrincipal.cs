using System.Security.Claims;

namespace My_Place_Backend.Authorization
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal? principal)
        {
            string? userId = principal?.FindFirstValue("Id");

            return userId!;
        }

        public static string GetUserRole(this ClaimsPrincipal? principal)
        {
            string? userId = principal?.FindFirstValue("Role");

            return userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}