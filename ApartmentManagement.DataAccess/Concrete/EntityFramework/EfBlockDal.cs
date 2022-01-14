using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.DataAccess.Context;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfBlockDal : EfEntityRepositoryBase<Block, ApartmentManagementDbContext>, IBlockDal
    {
    }
}
