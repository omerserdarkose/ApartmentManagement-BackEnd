using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Core.Entities.Concrete;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IClaimDal : IEntityRepository<Claim>
    {
    }
}
