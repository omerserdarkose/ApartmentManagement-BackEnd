using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Core.Utilities.Security;
using ApartmentManagement.Core.Utilities.Security.Hashing;
using ApartmentManagement.Entities.Dtos.User;
using AutoMapper;

namespace ApartmentManagement.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userManager;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;

        public AuthManager(IUserService userManager, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public IDataResult<UserViewDto> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userManager.GetByMail(userForLogin.Email);

            if (userToCheck is null)
            {
                return new ErrorDataResult<UserViewDto>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash,
                    userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<UserViewDto>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserViewDto>(_mapper.Map<UserViewDto>(userToCheck),
                Messages.UserLoginSuccessful);

        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var userClaims = _userManager.GetClaims(user.Id);

            var accessToken = _tokenHelper.CreateToken(user, _mapper.Map<List<Claim>>(userClaims));

            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
