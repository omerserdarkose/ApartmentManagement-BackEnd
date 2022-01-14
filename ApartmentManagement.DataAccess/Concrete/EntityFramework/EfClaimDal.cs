using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.DataAccess.Context;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfClaimDal : EfEntityRepositoryBase<Claim, ApartmentManagementDbContext>, IClaimDal
    {
    }
}
