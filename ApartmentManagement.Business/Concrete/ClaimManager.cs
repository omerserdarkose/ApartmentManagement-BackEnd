using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Dtos.Claim;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Claim = ApartmentManagement.Core.Entities.Concrete.Claim;

namespace ApartmentManagement.Business.Concrete
{
    public class ClaimManager:IClaimService
    {
        private IClaimDal _claimDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;


        public ClaimManager(IClaimDal claimDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _claimDal = claimDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public IDataResult<List<ClaimViewDto>> GetAll()
        {
            var claimList = _claimDal.GetList();
            if (claimList is null)
            {
                return new ErrorDataResult<List<ClaimViewDto>>(Messages.ClaimListNoxExist);
            }

            var claımViewList = _mapper.Map<List<ClaimViewDto>>(claimList);
            return new SuccessDataResult<List<ClaimViewDto>>(claımViewList);
        }

        public IResult Add(ClaimAddDto claimAddDto)
        {
            var claimCheck = _claimDal.Any(x => x.Name == claimAddDto.Name);
            if (claimCheck)
            {
                return new ErrorResult(Messages.ClaimAlreadyExist);
            }

            var newClaim = _mapper.Map<Claim>(claimAddDto);
            newClaim.IuserId = _currentUserId;
            newClaim.Idate = DateTime.Now;
            _claimDal.Add(newClaim);
            return new SuccessResult(Messages.ClaimAdded);
        }

        public IResult Update(ClaimUpdateDto claimUpdateDto)
        {
            var claim = _claimDal.Get(x => x.Id == claimUpdateDto.Id);
            if (claim is null)
            {
                return new ErrorResult(Messages.ClaimNotFound);
            }

            claim = _mapper.Map(claimUpdateDto, claim);
            claim.UuserId = _currentUserId;
            claim.Udate = DateTime.Now;
            _claimDal.Add(claim);
            return new SuccessResult(Messages.ClaimUpdated);
        }

        public IResult Delete(int claimId)
        {
            var claim = _claimDal.Get(x => x.Id == claimId);
            if (claim is null)
            {
                return new ErrorResult(Messages.ClaimNotFound);
            }

            claim.IsActive = false;
            claim.UuserId = _currentUserId;
            claim.Udate = DateTime.Now;
            _claimDal.Update(claim);
            return new SuccessResult(Messages.ClaimRemoved);
        }
    }
}
