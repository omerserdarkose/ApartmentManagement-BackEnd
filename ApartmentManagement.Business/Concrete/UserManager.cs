using System.Collections.Generic;
using System.Linq;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.User;
using AutoMapper;

namespace ApartmentManagement.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        //private IAuthService _authManager;
        private IMapper _mapper;

        public UserManager(IUserDal userDal, /*IAuthService authManager*/ IMapper mapper)
        {
            _userDal = userDal;
            //_authManager = authManager;
            _mapper = mapper;
        }

        public IDataResult<List<UserViewDto>> GetAll()
        {
            var userList = _userDal.GetUserList();

            return new SuccessDataResult<List<UserViewDto>>(userList);
        }

        public IResult Add(User newUser)
        {
            _userDal.Add(newUser);
            return new SuccessResult();
        }

        public IResult AddWithDetails(UserAddDto newUserWithDetails)
        {
            /*var result = _authManager.UserNotExists(newUserWithDetails.Email);

            if (!result.Success)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            var userIdentityInfo=_authManager.Register(_mapper.Map<UserForRegisterDto>(newUserWithDetails));

            var newUserId = GetUserId(newUserWithDetails.Email);
            var userDetail = _mapper.Map<UserDetail>(newUserWithDetails);
            userDetail.Id = newUserId;
            _userDetailManager.Add(userDetail);

            var apartment = _apartmentManager.GetById(newUserWithDetails.ApartmentId);
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
            var updateUser = GetByMail(userUpdateInfo.Email);
            updateUser = _mapper.Map(userUpdateInfo, updateUser);
            _userDal.Update(updateUser);

            return new SuccessResult(Messages.UserUpdated);
        }

        public User GetByMail(string mail)
        {
            var user = _userDal.Get(x => x.Email == mail);
            return user;
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

    }
}