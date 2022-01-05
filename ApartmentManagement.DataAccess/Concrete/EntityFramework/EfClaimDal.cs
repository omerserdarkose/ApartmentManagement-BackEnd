using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfClaimDal : EfRepositoryBase<Claim, ApartmentManagementDbContext>, IClaimDal
    {
    }
}
