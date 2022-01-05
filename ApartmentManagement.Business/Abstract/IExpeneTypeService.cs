using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Abstract
{
    public interface IExpeneTypeService
    {
        IDataResult<List<ExpenseTypeViewDto>> GetAll();

        IResult Add(ExpenseTypeAddDto expenseTypeAddDto);

        IResult Delete(ExpenseTypeDeleteDto expenseTypeDeleteDto);

        IResult Update(ExpenseTypeUpdateDto expenseTypeUpdateDto);
    }
}
