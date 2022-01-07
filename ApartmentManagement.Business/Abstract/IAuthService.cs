using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Core.Utilities.Security;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserIdentityDto> Register(UserForRegisterDto userForRegister);

        IDataResult<UserViewDto> Login(UserForLoginDto userForLogin);

        IDataResult<AccessToken> CreateAccessToken(User user);

        IResult UserNotExists(string email);

        IResult PasswordReset(string mail);
    }
}
