using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IExpenseTypeDal : IEntityRepository<ExpenseType>
    {
    }
}
