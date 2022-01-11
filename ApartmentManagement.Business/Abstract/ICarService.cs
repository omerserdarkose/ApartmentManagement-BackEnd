using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.Car;

namespace ApartmentManagement.Business.Abstract
{
    public interface ICarService
    {
        IResult Add(CarAddDto carAddDto);

        IDataResult<List<CarViewDto>> GetAll();

        IDataResult<List<CarViewDto>> GetByUserId(int userId);

        IResult Update(CarUpdateDto carUpdateDto);
        IResult Delete(int carId);
        
    }
}
