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
using PasswordGenerator;

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

        public IDataResult<UserIdentityDto> Register(UserForRegisterDto userForRegister)
        {
            userForRegister.Password = CreatePassword();

            HashingHelper.CreatePasswordHash(userForRegister.Password, out var passwordHash, out var passwordSalt);

            var newUser = _mapper.Map<User>(userForRegister);
            newUser.PasswordSalt = passwordSalt;
            newUser.PasswordHash = passwordHash;
            _userManager.Add(newUser);

            return new SuccessDataResult<UserIdentityDto>(new UserIdentityDto()
            {
                Email = newUser.Email,
                Password = userForRegister.Password
            });
        }

        private string CreatePassword()
        {
            var pwd = new Password(includeLowercase: true, includeUppercase: true, includeNumeric: true, includeSpecial: true,
                passwordLength: 10);
            return pwd.Next();
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

        public IResult UserNotExists(string email)
        {
            if (_userManager.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();
        }

        public IResult PasswordReset(string mail)
        {
            var userToCheck = _userManager.GetByMail(mail);

            if (userToCheck is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            var newPassword = CreatePassword();

            HashingHelper.CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);
            userToCheck.PasswordSalt = passwordSalt;
            userToCheck.PasswordHash = passwordHash;
            _userManager.Update(_mapper.Map<UserUpdateDto>(userToCheck));

            return new SuccessResult(Messages.UserPasswordReset);

        }
    }
}
