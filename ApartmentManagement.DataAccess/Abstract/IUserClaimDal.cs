using ApartmentManagement.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.UserClaim;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserClaimDal : IEntityRepository<UserClaim>
    {
        List<UserClaimListViewDto> GetUserClaimListWithDetails(
            Expression<Func<UserClaimListViewDto, bool>> filter = null);
    }
}
