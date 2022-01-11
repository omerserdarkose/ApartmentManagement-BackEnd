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
using ApartmentManagement.Entities.Dtos.Apartment;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class ApartmentManager:IApartmentService
    {
        private IApartmentDal _apartmentDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;

        public ApartmentManager(IApartmentDal apartmentDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _apartmentDal = apartmentDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public IDataResult<List<ApartmentViewDto>> GetAll()
        {
            var result = _apartmentDal.GetListWithDetails();
            return new SuccessDataResult<List<ApartmentViewDto>>(result);

        }

        public IResult Add(ApartmentAddDto apartmentAddDto)
        {
            var apartmentCheck = _apartmentDal.Any(x =>
                x.BlockId == apartmentAddDto.BlockId && x.DoorNumber == apartmentAddDto.DoorNumber);

            if (apartmentCheck)
            {
                return new ErrorResult(Messages.ApartmentAlreadyExist);
            }

            var newApartment = _mapper.Map<Apartment>(apartmentAddDto);
            newApartment.IuserId = _currentUserId;
            newApartment.Idate=DateTime.Now;
            _apartmentDal.Add(newApartment);

            return new SuccessResult(Messages.ApartmentAdded);
        }

        public IResult Update(ApartmentUpdateDto apartmentUpdateDto)
        {
            var apartment = _apartmentDal.Get(x =>x.Id==apartmentUpdateDto.Id);

            if (apartment is null)
            {
                return new ErrorResult(Messages.ApartmentNotFound);
            }

            apartment = _mapper.Map(apartmentUpdateDto,apartment);
            apartment.UuserId = _currentUserId;
            apartment.Udate = DateTime.Now;
            _apartmentDal.Update(apartment);

            return new SuccessResult(Messages.ApartmentUpdated);
        }

        public IResult UpdateUser(ApartmentUserUpdateDto apartmentUserUpdateDto)
        {
            var apartment = _apartmentDal.Get(x => x.Id == apartmentUserUpdateDto.ApartmentId);

            if (apartment is null)
            {
                return new ErrorResult(Messages.ApartmentNotFound);
            }

            //kiraci bilgisi degistiriliyorsa
            if (apartmentUserUpdateDto.IsHirer)
            {
                //kiraci giris yapiyorsa
                if (apartmentUserUpdateDto.IsResident)
                {
                    apartment.HirerId = apartmentUserUpdateDto.UserId;
                    apartment.Status=true;
                }
                //kiraci cikiyorsa
                else
                {
                    apartment.HirerId = null;
                    apartment.Status = true;
                }
            }
            //degisen bilgi ev sahibine aitse
            else
            {
                apartment.OwnerId = apartmentUserUpdateDto.UserId;
                //ev sahibi evde oturacaksa
                if (apartmentUserUpdateDto.IsResident)
                {
                    apartment.Status = true;
                }
            }

            apartment.UuserId = _currentUserId;
            apartment.Udate = DateTime.Now;
            _apartmentDal.Update(apartment);

            return new SuccessResult(Messages.ApartmentUpdated);
        }


        //ISLEVSELLIGINI KONTROL ET, REVIZYON SONRASI ISE YARAYABILIR DIYE BIRAKTIN
        public IResult UpdateStatus(int apartmentId, bool status)
        {
            var apartment = _apartmentDal.Get(x => x.Id == apartmentId);

            if (apartment is null)
            {
                return new ErrorResult(Messages.ApartmentNotFound);
            }

            apartment.Status = status;
            apartment.UuserId = _currentUserId;
            apartment.Udate = DateTime.Now;
            _apartmentDal.Update(apartment);

            return new SuccessResult(Messages.ApartmentUpdated);
        }

        public IResult Delete(int apartmentId)
        {
            var apartment = _apartmentDal.Get(x => x.Id == apartmentId);

            if (apartment is null)
            {
                return new ErrorResult(Messages.ApartmentNotFound);
            }

            apartment.IsActive = false;
            apartment.UuserId = _currentUserId;
            apartment.Udate = DateTime.Now;
            _apartmentDal.Update(apartment);

            return new SuccessResult(Messages.ApartmentUpdated);
        }

    }
}
