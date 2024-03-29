﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Extensions;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class ApartmentManager:IApartmentService
    {
        private IApartmentDal _apartmentDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public ApartmentManager(IApartmentDal apartmentDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _apartmentDal = apartmentDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<List<ApartmentViewDto>> GetAll()
        {
            var result = _apartmentDal.GetListWithDetails();
            return new SuccessDataResult<List<ApartmentViewDto>>(result);

        }

        public IDataResult<List<UserViewDto>> GetAllResident()
        {
            var userList = _apartmentDal.GetResidentList();

            return new SuccessDataResult<List<UserViewDto>>(userList);
        }

        public List<int> GetIdList()
        {
            var idList = _apartmentDal.GetApartmentIdList();
            return idList;
        }

        public int GetIdByResidentId(int residentId)
        {
            var isHirer = IsHirer(residentId);
            
            return isHirer? _apartmentDal.Get(x => x.HirerId == residentId).Id: _apartmentDal.Get(x => x.OwnerId == residentId).Id; 
        }

        public bool IsHirer(int residentId)
        {
            var isHirer = _apartmentDal.Any(x => x.HirerId == residentId);
            return isHirer;
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
            newApartment.IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
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
            apartment.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
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

            apartment.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
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
            apartment.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
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
            apartment.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            apartment.Udate = DateTime.Now;
            _apartmentDal.Update(apartment);

            return new SuccessResult(Messages.ApartmentUpdated);
        }

    }
}
