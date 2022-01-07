using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;

namespace ApartmentManagement.Core.Utilities.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<Claim> userClaims);
    }
}
