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
using ApartmentManagement.Entities.Dtos.ApartmentExpense;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class ApartmentExpenseManager:IApartmentExpenseService
    {
        private IApartmentExpenseDal _apartmentExpenseDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private IApartmentService _apartmentManager;
        private int _currentUserId;


        public ApartmentExpenseManager(IApartmentExpenseDal apartmentExpenseDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, IApartmentService apartmentManager)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _apartmentManager = apartmentManager;
            _apartmentExpenseDal = apartmentExpenseDal;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }

        public IResult Add(ApartmentExpenseAddDto apartmentExpenseAddDto)
        {
            var expenseCheck = _apartmentExpenseDal.Any(x => x.ApartmentId == apartmentExpenseAddDto.ApartmentId && x.ExpenseId==apartmentExpenseAddDto.ExpenseId);
            if (expenseCheck)
            {
                return new ErrorResult(Messages.ApartmentExpenseAlreadyExist);
            }

            var newApartmentExpense = _mapper.Map<ApartmentExpense>(apartmentExpenseAddDto);
            newApartmentExpense.DidPay = false;
            newApartmentExpense.IsActive = true;
            newApartmentExpense.IuserId = _currentUserId;
            newApartmentExpense.Idate = DateTime.Now;
            _apartmentExpenseDal.Add(newApartmentExpense);
            return new SuccessResult(Messages.ApartmentExpenseAdded);
        }

        //UPTADE METODU SADECE BURADA OLACAK
        //BU TABLO ICIN BASKA UPDATE GEREKMIYOR
        public IResult Pay(int expenseId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ApartmentExpenseViewDto>> GetUnPaidPayments()
        {
            var apartmentId = _apartmentManager.GetIdByResidentId(_currentUserId);
            var pendingPayments = _apartmentExpenseDal.GetUnPaidPayments(x=>x.ApartmentId==apartmentId);
            if (pendingPayments is null)
            {
                return new SuccessDataResult<List<ApartmentExpenseViewDto>>(Messages.PendingPaymentsNotFound);
            }

            return new SuccessDataResult<List<ApartmentExpenseViewDto>>(pendingPayments);
        }

     
        public IDataResult<List<ApartmentExpenseViewDto>> GetPaidPayments()
        {
            var apartmentId = _apartmentManager.GetIdByResidentId(_currentUserId);
            var paidPayments = _apartmentExpenseDal.GetPaidPayments(x => x.ApartmentId == apartmentId);
            if (paidPayments is null)
            {
                return new SuccessDataResult<List<ApartmentExpenseViewDto>>(Messages.PendingPaymentsNotFound);
            }

            return new SuccessDataResult<List<ApartmentExpenseViewDto>>(paidPayments);
        }

        public bool IsFullyPaid(int expenseId)
        {
            var check = _apartmentExpenseDal.Any(x => x.ExpenseId == expenseId && x.DidPay == false);
            if (check)
            {
                return false;
            }

            return true;
        }
    }
}
