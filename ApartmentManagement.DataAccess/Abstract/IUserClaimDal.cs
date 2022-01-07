using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserClaimDal : IEntityRepository<UserClaim>
    {
    }
}
