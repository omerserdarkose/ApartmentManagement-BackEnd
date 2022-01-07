using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ApartmentManagementDbContext>, IUserDal
    {
        public List<UserViewDto> GetUserList()
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = from contextUser in context.Users
                             join apartment in context.Apartments
                                 on contextUser.Id equals apartment.UserId
                             join userDetail in context.UserDetails
                                 on contextUser.Id equals userDetail.Id
                             join block in context.Blocks
                                 on apartment.BlockId equals block.Id
                             where contextUser.IsActive == true
                             select new UserViewDto()
                             {
                                 Id = contextUser.Id,
                                 Name = contextUser.FirstName + " " + contextUser.LastName,
                                 PhoneNumber = userDetail.PhoneNumber,
                                 Email = contextUser.Email,
                                 Block = block.Letter.ToUpper(),
                                 DoorNumber = apartment.DoorNumber
                             };
                return result.ToList();
            }

        }
    }
}
