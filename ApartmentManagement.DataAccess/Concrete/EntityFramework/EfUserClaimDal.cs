using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.DataAccess.Context;
using ApartmentManagement.Entities.Dtos.UserClaim;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfUserClaimDal : EfEntityRepositoryBase<UserClaim, ApartmentManagementDbContext>, IUserClaimDal
    {

        public List<UserClaimListViewDto> GetUserClaimListWithDetails(Expression<Func<UserClaimListViewDto, bool>> filter = null)
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = from userClaim in context.UserClaims
                             join user in context.Users
                                 on userClaim.UserId equals user.Id
                             join claim in context.Claims
                             on userClaim.ClaimId equals claim.Id
                             where userClaim.IsActive==true
                             select new UserClaimListViewDto()
                             {
                                 Id = userClaim.Id,
                                 UserId = user.Id,
                                 UserName = user.FirstName + " " + user.LastName,
                                 ClaimId = userClaim.ClaimId,
                                 ClaimName = claim.Name
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
