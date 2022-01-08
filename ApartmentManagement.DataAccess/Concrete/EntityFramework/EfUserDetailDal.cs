using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.UserDetail;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfUserDetailDal : EfEntityRepositoryBase<UserDetail, ApartmentManagementDbContext>, IUserDetailDal
    {
        public UserDetailViewDto GetForView(int userId)
        {
            using (var context=new ApartmentManagementDbContext())
            {
                var result=from userDetail in context.UserDetails
                    join user in context.Users
                        on userDetail.Id=user.Id
                        where userDetail.Id==userId
                           select new UserDetailViewDto()
                           {
                               Name = user.Fi
                           }
            }
        }
    }
}


/*public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNo { get; set; }*/