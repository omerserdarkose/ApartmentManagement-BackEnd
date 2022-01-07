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
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Concrete
{
    public class ExpenseTypeManager : IExpeneTypeService
    {
        private IExpenseTypeDal _expenseTypeDal;
        private IMapper _mapper;

        public ExpenseTypeManager(IExpenseTypeDal expenseTypeDal, IMapper mapper)
        {
            _expenseTypeDal = expenseTypeDal;
            _mapper = mapper;
        }

        public IResult Add(ExpenseTypeAddDto expenseTypeAddDto)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(expenseTypeAddDto);
            _expenseTypeDal.Add(mapExpenseType);

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
            _expenseTypeDal.Update(expenseType);

            return new SuccessResult(Messages.ExpenseTypeDeleted);
        }

        public IDataResult<List<ExpenseTypeViewDto>> GetAll()
        {
            var expenseTypeList = _expenseTypeDal.GetList(x=>x.IsActive==true);
            var expenseTypeViewList = _mapper.Map<List<ExpenseTypeViewDto>>(expenseTypeList);

            return new SuccessDataResult<List<ExpenseTypeViewDto>>(expenseTypeViewList);
        }

        public IResult Update(ExpenseTypeUpdateDto expenseTypeUpdateDto)
        {
            var mapExpenseType = _mapper.Map<ExpenseType>(expenseTypeUpdateDto);
            _expenseTypeDal.Update(mapExpenseType);

            return new SuccessResult(Messages.ExpenseTypeUpdated);
        }
    }
}
