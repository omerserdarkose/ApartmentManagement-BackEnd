using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Extensions;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.User;
using ApartmentManagement.Entities.Dtos.UserClaim;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Claim = ApartmentManagement.Core.Entities.Concrete.Claim;

namespace ApartmentManagement.Business.Concrete
{
    public class UserClaimManager:IUserClaimService
    {
        private IUserClaimDal _userClaimDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        public UserClaimManager(IUserClaimDal userClaimDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userClaimDal = userClaimDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<List<UserClaimListViewDto>> GetUserClaimList()
        {
            var userClaimList = _userClaimDal.GetUserClaimListWithDetails();
            if (userClaimList is null)
            {
                return new ErrorDataResult<List<UserClaimListViewDto>>(Messages.UserClaimListNoxExist);
            }
            return new SuccessDataResult<List<UserClaimListViewDto>>(userClaimList);
        }

        public IResult Add(UserClaimAddDto userClaimAddDto)
        {
            var check = _userClaimDal.Any(x => x.UserId == userClaimAddDto.UserId && x.ClaimId == userClaimAddDto.ClaimId);
            if (check)
            {
                return new ErrorResult(Messages.UserClaimAlreadyExist);
            }

            var newUserClaim = _mapper.Map<UserClaim>(userClaimAddDto);
            newUserClaim.IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            newUserClaim.Idate = DateTime.Now;
            _userClaimDal.Add(newUserClaim);
            return new SuccessResult(Messages.UserClaimAdded);
        }

        public IResult AddDefault(int userId, short claimId = 2)
        {
            _userClaimDal.Add(new UserClaim()
            {
                UserId = userId,
                ClaimId = claimId,
                IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId(),
                Idate = DateTime.Now
            });
            return new SuccessResult(Messages.UserClaimAdded);
        }

        public IResult Update(UserClaimUpdateDto userClaimUpdateDto)
        {
            var userClaim = (_userClaimDal).Get(x => x.Id == userClaimUpdateDto.Id);
            if (userClaim is null)
            {
                return new ErrorResult(Messages.UserClaimNotFound);
            }

            userClaim = _mapper.Map(userClaimUpdateDto, userClaim);
            userClaim.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            userClaim.Udate = DateTime.Now;
            _userClaimDal.Add(userClaim);
            return new SuccessResult(Messages.UserClaimUpdated);
        }

        public IResult Delete(int userClaimId)
        {
            var userClaim = _userClaimDal.Get(x => x.Id == userClaimId);
            if (userClaim is null)
            {
                return new ErrorResult(Messages.UserClaimNotFound);
            }

            var claimCount = _userClaimDal.GetList(x => x.UserId == userClaim.UserId).Count;
            if (claimCount <= 1)
            {
                return new ErrorResult(Messages.UserClaimCanNotBeRemoved);
            }

            userClaim.IsActive = false;
            userClaim.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            userClaim.Udate = DateTime.Now;
            _userClaimDal.Update(userClaim);
            return new SuccessResult(Messages.CarRemoved);
        }
    }
}
