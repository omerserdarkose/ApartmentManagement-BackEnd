using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities;
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
            throw new NotImplementedException();
        }

        public IResult Delete(ExpenseTypeDeleteDto expenseTypeDeleteDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ExpenseTypeViewDto>> GetAll()
        {
            var expenseTypeList = _expenseTypeDal.GetList();
            var expenseTypeViewList = _mapper.Map<List<ExpenseTypeViewDto>>(expenseTypeList);

            return new SuccessDataResult<List<ExpenseTypeViewDto>>(expenseTypeViewList);
        }

        public IResult Update(ExpenseTypeUpdateDto expenseTypeUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
