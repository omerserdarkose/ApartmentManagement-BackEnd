using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Aspects.Autofac;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.ApartmentExpense;
using ApartmentManagement.Entities.Dtos.Expense;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseDal _expenseDal;
        private IMapper _mapper;
        private IApartmentService _apartmentManager;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;
        private IApartmentExpenseService _apartmentExpenseManager;

        public ExpenseManager(IExpenseDal expenseDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, IApartmentService apartmentManager, IApartmentExpenseService apartmentExpenseManager)
        {
            _expenseDal = expenseDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _apartmentManager = apartmentManager;
            _apartmentExpenseManager = apartmentExpenseManager;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public void Add(ExpenseAddForAllDto expenseAddDto)
        {
            var newExpense = _mapper.Map<Expense>(expenseAddDto);
            newExpense.IuserId = _currentUserId;
            newExpense.Idate = DateTime.Now;
            newExpense.IsActive = true;
            _expenseDal.Add(newExpense);
        }

        public int GetLastExpenseId()
        {
            return _expenseDal.GetLastMessageId();
        }

        public IDataResult<List<ExpenseViewDto>> GetList()
        {
            var expenseList = _expenseDal.GetListWithPaymentInfo();
            if (expenseList is null)
            {
                return new SuccessDataResult<List<ExpenseViewDto>>(Messages.ExpenseListNotFound);
            }

            return new SuccessDataResult<List<ExpenseViewDto>>(expenseList);
        }

        public IDataResult<List<ExpenseViewDto>> GetListFilterDate(DateTime dateTime)
        {
            var expenseList = _expenseDal.GetListWithPaymentInfo( x => x.Date.Month == dateTime.Month&&x.Date.Year==dateTime.Year);
            if (expenseList is null)
            {
                return new SuccessDataResult<List<ExpenseViewDto>>(Messages.ExpenseFilterListNotFound);
            }

            return new SuccessDataResult<List<ExpenseViewDto>>(expenseList);
        }
        

        public IResult Update(ExpenseUpdateDto expenseUpdateDto)
        {
            var expense = _expenseDal.Get(x => x.Id == expenseUpdateDto.Id);

            if (expense is null)
            {
                return new ErrorResult(Messages.ExpenseNotFound);
            }

            expense = _mapper.Map(expenseUpdateDto, expense);
            expense.UuserId = _currentUserId;
            expense.Udate = DateTime.Now;
            _expenseDal.Update(expense);
            return new SuccessResult(Messages.ExpenseUpdated);
        }

        public IResult Delete(int expenseId)
        {
            var expense = _expenseDal.Get(x => x.Id == expenseId);

            if (expense is null)
            {
                return new ErrorResult(Messages.ExpenseNotFound);
            }

            if (!_apartmentExpenseManager.IsFullyPaid(expenseId))
            {
                return new ErrorResult(Messages.ExpenseCanNotBeRemoved);
            }

            expense.IsActive = false;
            expense.UuserId = _currentUserId;
            expense.Udate = DateTime.Now;
            _expenseDal.Update(expense);

            return new SuccessResult(Messages.ExpenseRemoved);
        }

        [TransactionScopeAspect]
        public IResult AddExpenseForAll(ExpenseAddForAllDto expenseAddDto)
        {

            Add(expenseAddDto);

            var expenseId = GetLastExpenseId();

            var apartmentIdList = _apartmentManager.GetIdList();

            foreach (var apartment in apartmentIdList.ToArray())
            {
                _apartmentExpenseManager.Add(new ApartmentExpenseAddDto()
                {
                    ApartmentId = apartment,
                    ExpenseId = expenseId,
                });
            }

            return new SuccessResult(Messages.ExpenseAddedForAll);
        }

        public IResult AddExpenseForOne(ExpenseAddForOneDto expenseAddForOneDto)
        {
            var newExpense = _mapper.Map<ExpenseAddForAllDto>(expenseAddForOneDto);

            Add(newExpense);

            var expenseId = GetLastExpenseId();

            var apartmentId = expenseAddForOneDto.ApartmentId;

            _apartmentExpenseManager.Add(new ApartmentExpenseAddDto()
            {
                ApartmentId = apartmentId,
                ExpenseId = expenseId,
            });

            return new SuccessResult();
        }
    }
}
