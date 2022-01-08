using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using FluentValidation;

namespace ApartmentManagement.Business.Validation.FluentValidation
{
    public class ExpenseTypeValidator:AbstractValidator<ExpenseTypeAddDto>
    {
        public ExpenseTypeValidator()
        {
            RuleFor(et => et.Name).NotEmpty();
        }
    }
}
