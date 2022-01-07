using ApartmentManagement.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserViewDto> GetUserList();
    }
}
