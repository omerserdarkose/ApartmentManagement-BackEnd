using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.ApartmentExpense;

namespace ApartmentManagement.Business.Abstract
{
    public interface IApartmentExpenseService
    {
        IResult Add(ApartmentExpenseAddDto apartmentExpenseAddDto);
        IResult Pay(int expenseId);
        IDataResult<List<ApartmentExpenseViewDto>> GetUnPaidPayments(int apartmentId);
        IDataResult<List<ApartmentExpenseViewDto>> GetPaidPayments(int apartmentId);
        IDataResult<List<ApartmentExpenseViewDto>> GetMyUnPaidPayments();
        IDataResult<List<ApartmentExpenseViewDto>> GetMyPaidPayments();
        bool IsFullyPaid(int expenseId);
    }
}
