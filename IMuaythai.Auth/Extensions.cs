using System.Linq;
using System.Security.Claims;

namespace IMuaythai.Auth
{

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == "UserId");

            return userIdClaim?.Value;
        }
    }

}
