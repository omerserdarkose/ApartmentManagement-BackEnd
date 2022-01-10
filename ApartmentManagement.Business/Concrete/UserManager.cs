using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Aspects.Autofac;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Core.Utilities.Security.Hashing;
using ApartmentManagement.Core.Utilities.Security.PasswordCreator;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.User;
using ApartmentManagement.Entities.Dtos.UserDetail;
using AutoMapper;

namespace ApartmentManagement.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IUserDetailService _userDetailManager;
        private IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper, IUserDetailService userDetailManager)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userDetailManager = userDetailManager;
        }

        public IDataResult<List<UserViewDto>> GetAll()
        {
            var userList = _userDal.GetUserList();

            return new SuccessDataResult<List<UserViewDto>>(userList);
        }

        public IResult Add(User newUser)
        {
            //newUser.IuserId = currentUserId;
            //newUser.Idate = Datetime.Now;
            _userDal.Add(newUser);
            return new SuccessResult();
        }

        //[TransactionScopeAspect]
        public IResult AddWithDetails(UserAddWithDetailsDto newUserWithDetails)
        {
            var result = _userDal.Any(x => x.Email == newUserWithDetails.Email);

            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }


            var password = PasswordHelper.CreatePassword();

            HashingHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var newUser = _mapper.Map<User>(newUserWithDetails);
            newUser.PasswordSalt = passwordSalt;
            newUser.PasswordHash = passwordHash;
            var isUserAdd =Add(newUser);

            if (!isUserAdd.Success)
            {
                return new ErrorResult(Messages.UserAddFailed);
            }

            //var userIdentityInfo=_authManager.Register(_mapper.Map<UserAddDto>(newUserWithDetails));

            var newUserId = GetUserId(newUserWithDetails.Email);
            var userDetail = _mapper.Map<UserDetailAddDto>(newUserWithDetails);
            userDetail.Id = newUserId;
            var isUserDetailAdd=_userDetailManager.Add(userDetail);

            if (!isUserDetailAdd.Success)
            {
                return new ErrorResult(Messages.UserDetailAddFailed);
            }

            /*var apartment = _apartmentManager.GetById(newUserWithDetails.ApartmentId);
            apartment.IsHirer = newUserWithDetails.IsHirer;
            apartment.UserId = newUserId;
            _apartmentManager.Update(apartment);

            foreach (string licensePlate in newUserWithDetails.LicensePlate.ToArray())
            {
                _carManager.Add(new Car() {LicensePlate = licensePlate, UserId = newUserId});
            }*/

            return new SuccessResult(Messages.UserAddedWithInfos);
        }

        public IResult Delete(int userId)
        {
            var user = _userDal.Get(x => x.Id == userId);

            if (user is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            user.IsActive = false;
            _userDal.Update(user);

            return new SuccessResult(Messages.UserRemoved);
        }

        public IResult Update(UserUpdateDto userUpdateInfo)
        {
            var updateUser = GetById(userUpdateInfo.Id);
            updateUser = _mapper.Map(userUpdateInfo, updateUser);
            //updateUser.UuserId = currentUserId;
            //updateUser.Udate = Datetime.Now;
            _userDal.Update(updateUser);

            return new SuccessResult(Messages.UserUpdated);
        }

        public User GetByMail(string mail)
        {
            var user = _userDal.Get(x => x.Email == mail);
            return user;
        }

        public User GetById(int userId)
        {
            var user = _userDal.Get(x => x.Id==userId);
            return user;
        }

        public bool UserExists(int userId)
        {
            var result = _userDal.Any(x => x.Id==userId);
            return result;
        }

        public bool UserExists(string mail)
        {
            var result = _userDal.Any(x => x.Email == mail);
            return result;
        }

        public int GetUserId(string mail)
        {
            return _userDal.GetUserId(mail);
        }

        public List<UserClaimsViewDto> GetClaims(int userId)
        {
            var userClaims = _userDal.GetClaims(userId);

            return userClaims;
        }

        public IResult PasswordReset(int userId)
        {
            var userToCheck = GetById(userId);

            if (userToCheck is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            var newPassword = PasswordHelper.CreatePassword();

            HashingHelper.CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);

            userToCheck.PasswordSalt = passwordSalt;
            userToCheck.PasswordHash = passwordHash;
            Update(_mapper.Map<UserUpdateDto>(userToCheck));

            return new SuccessResult(Messages.UserPasswordReset);
        }

    }
}