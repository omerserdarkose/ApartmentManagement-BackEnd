using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.Car;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ApartmentManagementDbContext>, ICarDal
    {
        public List<CarViewDto> GetCarListWithDetails(Expression<Func<CarViewDto, bool>> filter = null)
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = from car in context.Cars
                             join user in context.Users
                                 on car.UserId equals user.Id
                             where car.IsActive == true
                             select new CarViewDto()
                             {
                                 Id = car.Id,
                                 UserId = user.Id,
                                 UserName = user.FirstName + " " + user.LastName,
                                 LicensePlate = car.LicensePlate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
