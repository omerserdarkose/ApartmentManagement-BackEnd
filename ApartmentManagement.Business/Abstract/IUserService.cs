using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace ApartmentManagement.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<UserViewDto>> GetAll();
       

        User GetByMail(string mail);
        User GetById(int userId);

        bool UserExistsId(int userId);

        bool UserExistsMail(string mail);

        int GetUserId(string mail);

        List<UserClaimsViewDto> GetClaims(int userId);

        IResult Add(User newUser);

        IResult AddWithDetails(UserAddWithDetailsDto newUserWithDetails);

        IResult Delete(int userId);

        IResult Update(UserUpdateDto userUpdateInfo);

        IResult PasswordReset(int userId);
    }
}
