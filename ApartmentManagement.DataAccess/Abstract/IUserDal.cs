using ApartmentManagement.Core.DataAccess;
using System.Collections.Generic;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserViewDto> GetUserList();
        List<UserClaimsViewDto> GetClaims(int userId);
        int GetUserId(string eMail);
        
    }
}
