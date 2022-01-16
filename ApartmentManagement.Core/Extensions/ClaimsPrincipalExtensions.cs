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
    }
}
