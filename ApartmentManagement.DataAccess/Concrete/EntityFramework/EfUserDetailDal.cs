using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System.Linq;
using ApartmentManagement.DataAccess.Context;
using ApartmentManagement.Entities.Dtos.UserDetail;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfUserDetailDal : EfEntityRepositoryBase<UserDetail, ApartmentManagementDbContext>, IUserDetailDal
    {
        public UserDetailViewDto GetForView(int userId)
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = from userDetail in context.UserDetails
                             join user in context.Users
                                 on userDetail.Id equals user.Id
                             where userDetail.Id == userId
                             select new UserDetailViewDto()
                             {
                                 Name = user.FirstName + " " + user.LastName,
                                 PhoneNumber = userDetail.PhoneNumber,
                                 IdentityNo = userDetail.IdentityNo
                             };
                return result.Single();
            }
        }
    }
}
