using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.Expense;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseDal : EfEntityRepositoryBase<Expense, ApartmentManagementDbContext>, IExpenseDal
    {
        public int GetLastMessageId()
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var id = context.Set<Expense>().ToList().Last().Id;
                return id;
            }
        }

        public List<ExpenseViewDto> GetListWithPaymentInfo(Expression<Func<ExpenseViewDto, bool>> filter = null)
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = (from expense in context.Expenses
                              join expenseType in context.ExpenseTypes
                              on expense.TypeId equals expenseType.Id
                              where expense.IsActive == true
                              select new ExpenseViewDto()
                              {
                                  Id = expense.Id,
                                  TypeName = expenseType.Name,
                                  Name = expense.Name,
                                  Amount = expense.Amount,
                                  Date = expense.Date,
                                  PaidCount = (from apartmentExpense in context.ApartmentExpenses
                                               where apartmentExpense.ExpenseId == expense.Id && apartmentExpense.DidPay == true
                                               select apartmentExpense.Id).Count(),
                                  UnPaidCount = (from apartmentExpense in context.ApartmentExpenses
                                                 where apartmentExpense.ExpenseId == expense.Id && apartmentExpense.DidPay == false
                                                 select apartmentExpense.Id).Count()

                              }).OrderBy(x => x.Date);
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
