using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.Expense;

namespace ApartmentManagement.Business.Abstract
{
    public interface IExpenseService
    {
        IResult Add(ExpenseAddDto expenseAddDto);
        IResult Update(ExpenseUpdateDto expenseUpdateDto);
        IResult Delete(int expenseId);
        IResult AddExpenseForAll(ExpenseAddDto expenseAddDto);
        IResult AddExpenseForOne(ExpenseAddForOneDto expenseAddForOneDto);
        int GetLastExpenseId();
        IDataResult<List<ExpenseViewDto>> GetList();
    }
}
