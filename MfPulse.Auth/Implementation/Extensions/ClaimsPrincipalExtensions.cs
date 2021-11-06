using System.Linq;
using System.Security.Claims;

namespace MfPulse.Auth.Implementation.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetClaim(this ClaimsPrincipal? claimsPrincipal, string key)
        {
            return claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == key)?.Value;
        }
    }
}