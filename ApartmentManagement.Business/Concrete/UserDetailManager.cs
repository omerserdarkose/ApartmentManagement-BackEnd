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
using ApartmentManagement.Entities.Dtos.UserDetail;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class UserDetailManager:IUserDetailService
    {
        private IUserDetailDal _userDetailDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public UserDetailManager(IUserDetailDal userDetailDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userDetailDal = userDetailDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<UserDetailViewDto> GetById(int userId)
        {
            var userDetail = _userDetailDal.GetForView(userId);

            if (userDetail is null)
            {
                return new ErrorDataResult<UserDetailViewDto>(Messages.UserDetailNotFound);
            }

            return new SuccessDataResult<UserDetailViewDto>(userDetail);
        }

        public IResult Add(UserDetailAddDto userDetailAdd)
        {
            var userDetailCheck = _userDetailDal.Any(x=>x.Id==userDetailAdd.Id);

            if (userDetailCheck)
            {
                return new ErrorResult(Messages.UserDetailAlreadyExist);
            }

            var newUserDetail=_mapper.Map<UserDetail>(userDetailAdd);
            newUserDetail.IuserId=_httpContextAccessor.HttpContext.User.GetLoggedUserId();
            newUserDetail.Idate=DateTime.Now;

            _userDetailDal.Add(newUserDetail);

            return new SuccessResult(Messages.UserDetailAdded);
        }

        public IResult Delete(int userId)
        {
            var userDetail = _userDetailDal.Get(x => x.Id == userId);

            if (userDetail is null)
            {
                return new ErrorResult(Messages.UserDetailNotFound);
            }

            userDetail.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            userDetail.Udate = DateTime.Now;

            userDetail.IsActive = false;
            _userDetailDal.Update(userDetail);

            return new SuccessResult(Messages.UserDetailRemoved);

        }

        public IResult Update(UserDetailUpdateDto userDetailUpdate)
        {
            var userDetail = _userDetailDal.Get(x => x.Id == userDetailUpdate.Id);

            if (userDetail is null)
            {
                return new ErrorResult(Messages.UserDetailNotFound);
            }

            userDetail = _mapper.Map(userDetailUpdate, userDetail);

            userDetail.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            userDetail.Udate = DateTime.Now;

            _userDetailDal.Update(userDetail);

            return new SuccessResult(Messages.UserDetailUpdated);
        }
    }
}
