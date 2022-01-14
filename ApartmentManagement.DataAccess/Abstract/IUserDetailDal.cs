using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.UserDetail;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserDetailDal : IEntityRepository<UserDetail>
    {
        UserDetailViewDto GetForView(int userId);
    }
}
