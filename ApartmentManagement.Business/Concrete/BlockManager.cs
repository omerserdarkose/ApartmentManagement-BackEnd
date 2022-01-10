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
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Block;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class BlockManager:IBlockService
    {
        private IBlockDal _blockDal;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;
        private IMapper _mapper;

        public BlockManager(IBlockDal blockDal, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _blockDal = blockDal;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public IDataResult<List<BlockViewDto>> GetAll()
        {
            var blockList=_blockDal.GetList(x=>x.IsActive==true);
            var blockViewList = _mapper.Map<List<BlockViewDto>>(blockList);
            return new SuccessDataResult<List<BlockViewDto>>(blockViewList);
        }

        public IResult Add(BlockAddDto blockAddDto)
        {
            var blockCheck = _blockDal.Any(x => x.Letter == blockAddDto.Letter);
            if (blockCheck)
            {
                return new ErrorResult(Messages.BlockLetterAlreadyExist);
            }

            var newBlock = _mapper.Map<Block>(blockAddDto);
            newBlock.IuserId = _currentUserId;
            newBlock.Idate=DateTime.Now;
            _blockDal.Add(newBlock);
            return new SuccessResult(Messages.BlockAdded);
        }

        public IResult Update(BlockUpdateDto updateBlockDto)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int blockId)
        {
            var deleteBlock= _blockDal.Get(x => x.Id == blockId);
            if (deleteBlock is null)
            {
                return new ErrorResult(Messages.BlockNotFound);
            }

            deleteBlock.IsActive = false;
            newBlock.IuserId = _currentUserId;
            newBlock.Idate = DateTime.Now;
            _blockDal.Add(newBlock);
            return new SuccessResult(Messages.BlockAdded);
        }
    }
}
