using ApartmentManagement.Entities;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Abstract
{
    public interface IExpensTypeService
    {
        IDataResult<List<ExpenseTypeViewDto>> GetAll();

        IResult Add(ExpenseTypeAddDto expenseTypeAddDto);

        IResult Delete(ExpenseTypeDeleteDto expenseTypeDeleteDto);

        IResult Update(ExpenseTypeUpdateDto expenseTypeUpdateDto);
    }
}
