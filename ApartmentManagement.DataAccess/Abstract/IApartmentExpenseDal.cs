using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApartmentManagement.Entities.Dtos.ApartmentExpense;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IApartmentExpenseDal : IEntityRepository<ApartmentExpense>
    {
        List<ApartmentExpenseViewDto> GetUnPaidPayments(Expression<Func<ApartmentExpenseViewDto, bool>> filter = null);
        List<ApartmentExpenseViewDto> GetPaidPayments(Expression<Func<ApartmentExpenseViewDto, bool>> filter = null);
    }
}
