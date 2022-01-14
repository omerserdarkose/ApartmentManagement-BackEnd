using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApartmentManagement.Entities.Dtos.Car;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarViewDto> GetCarListWithDetails(Expression<Func<CarViewDto, bool>> filter = null);
    }
}
