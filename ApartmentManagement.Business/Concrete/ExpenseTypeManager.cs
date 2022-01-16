using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Entities;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Validation.FluentValidation;
using ApartmentManagement.Core.Aspects.Autofac;
using ApartmentManagement.Core.Extensions;
using ApartmentManagement.Core.Utilities.Security;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class ExpenseTypeManager : IExpenseTypeService
    {
        private IExpenseTypeDal _expenseTypeDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public ExpenseTypeManager(IExpenseTypeDal expenseTypeDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _expenseTypeDal = expenseTypeDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [ValidationAspect(typeof(ExpenseTypeValidator))]
        public IResult Add(ExpenseTypeAddDto expenseTypeAddDto)
        {
            var expenseType = _mapper.Map<ExpenseType>(expenseTypeAddDto);
            expenseType.IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            expenseType.Idate=DateTime.Now;
            _expenseTypeDal.Add(expenseType);

            return new SuccessResult(Messages.ExpenseTypeAdded);
        }

        public IResult Delete(int expenseTypeId)
        {
            var expenseType=_expenseTypeDal.Get(x => x.Id == expenseTypeId);
            if(expenseType is null)
            {
                return new ErrorResult(Messages.ExpenseTypeNotFound);
            }
            expenseType.IsActive = false;
            expenseType.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            expenseType.Udate = DateTime.Now;
            _expenseTypeDal.Update(expenseType);

            return new SuccessResult(Messages.ExpenseTypeRemoved);
        }


        public IDataResult<List<ExpenseTypeViewDto>> GetAll()
        {
            var x=_httpContextAccessor.HttpContext.User.GetLoggedUserId();
            var expenseTypeList = _expenseTypeDal.GetList(x=>x.IsActive==true);
            var expenseTypeViewList = _mapper.Map<List<ExpenseTypeViewDto>>(expenseTypeList);

            return new SuccessDataResult<List<ExpenseTypeViewDto>>(expenseTypeViewList);
        }

        public IResult Update(ExpenseTypeUpdateDto expenseTypeUpdateDto)
        {
            var expenseType = _expenseTypeDal.Get(x=>x.Id==expenseTypeUpdateDto.Id);
            if (expenseType is null)
            {
                return new ErrorResult(Messages.ExpenseTypeNotFound);
            }

            expenseType = _mapper.Map(expenseTypeUpdateDto, expenseType);
            expenseType.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            expenseType.Udate = DateTime.Now;

            _expenseTypeDal.Update(expenseType);

            return new SuccessResult(Messages.ExpenseTypeUpdated);
        }
    }
}
