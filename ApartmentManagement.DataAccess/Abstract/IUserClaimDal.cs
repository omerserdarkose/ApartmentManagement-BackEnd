using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.UserClaim;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserClaimDal : IEntityRepository<UserClaim>
    {
        List<UserClaimListViewDto> GetUserClaimListWithDetails(Expression<Func<UserClaimListViewDto, bool>> filter = null)
    }
}
