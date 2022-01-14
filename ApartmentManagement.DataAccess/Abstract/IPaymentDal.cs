using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IPaymentDal: IEntityRepository<Payment>
    {
    }
}
