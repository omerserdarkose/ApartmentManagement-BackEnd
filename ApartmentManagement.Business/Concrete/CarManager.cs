using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Car;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;
        
        public CarManager(ICarDal carDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _carDal = carDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }


        public IResult Add(CarAddDto carAddDto)
        {
            var carCheck = _carDal.Any(x => x.LicensePlate == carAddDto.LicensePlate);
            if (carCheck)
            {
                return new ErrorResult(Messages.CarAlreadyExist);
            }

            var newCar = _mapper.Map<Car>(carAddDto);
            newCar.IuserId = _currentUserId;
            newCar.Idate=DateTime.Now;
            newCar.IsActive = true;
            _carDal.Add(newCar);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<CarViewDto>> GetAll()
        {
            var carList = _carDal.GetCarListWithDetails();
            if (carList is null)
            {
                return new ErrorDataResult<List<CarViewDto>>(Messages.CarListNoxExist);
            }
            return new SuccessDataResult<List<CarViewDto>>(carList);
        }

        public IDataResult<List<CarViewDto>> GetByUserId(int userId)
        {
            var carList = _carDal.GetCarListWithDetails(x=>x.UserId==userId);
            if (carList is null)
            {
                return new ErrorDataResult<List<CarViewDto>>(Messages.UserCarNotFound);
            }
            return new SuccessDataResult<List<CarViewDto>>(carList);
        }

        public IResult Update(CarUpdateDto carUpdateDto)
        {
            var car = _carDal.Get(x => x.LicensePlate == carUpdateDto.LicensePlate);
            if (car is null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            car = _mapper.Map(carUpdateDto, car);
            car.UuserId = _currentUserId;
            car.Udate = DateTime.Now;
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(int carId)
        {
            var car = _carDal.Get(x => x.Id == carId);
            if (car is null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            car.IsActive = false;
            car.UuserId = _currentUserId;
            car.Udate = DateTime.Now;
            _carDal.Update(car);
            return new SuccessResult(Messages.CarRemoved);
        }
    }
}
