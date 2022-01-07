using System.Collections.Generic;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<UserViewDto>> GetAll()
        {
            var userList = _userDal.GetUserList();

            return new SuccessDataResult<List<UserViewDto>>(userList);
        }

        public User GetByMail(string mail)
        {
            var user=_userDal.Get(x=>x.Email==mail);
            return user;
        }

        public IResult Add(UserAddDto newUser)
        {
            throw new System.NotImplementedException();
        }
        
        public IResult Delete(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(UserUpdateDto updateUser)
        {
            throw new System.NotImplementedException();
        }
    }
}