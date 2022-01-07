using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<UserViewDto>> GetAll();

        User GetByMail(string mail);

        IResult Add(UserAddDto newUser);

        IResult Delete(int userId);

        IResult Update(UserUpdateDto updateUser);
    }
}
