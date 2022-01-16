using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetLoggedUserId(this ClaimsPrincipal principal)
        {
            var currentUserId = Convert.ToInt32(principal.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            return currentUserId;
        }

        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
