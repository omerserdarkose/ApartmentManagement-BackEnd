using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.UserDetail;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserDetailDal : IEntityRepository<UserDetail>
    {
        UserDetailViewDto GetForView(int userId);
    }
}
