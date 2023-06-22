using System.Security.Claims;

namespace Tescaro.GBT.API.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email)?.Value;
        }

        public static long GetUserId(this ClaimsPrincipal user)
        {
            return long.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
