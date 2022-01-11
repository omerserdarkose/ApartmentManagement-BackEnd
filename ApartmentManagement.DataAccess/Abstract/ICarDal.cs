using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.Car;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarViewDto> GetCarListWithDetails(Expression<Func<CarViewDto, bool>> filter = null);
    }
}
