using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.Expense;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IExpenseDal : IEntityRepository<Expense>
    {
        int GetLastMessageId();
        List<ExpenseViewDto> GetListWithPaymentInfo(Expression<Func<ExpenseViewDto, bool>> filter = null);
    }
}
