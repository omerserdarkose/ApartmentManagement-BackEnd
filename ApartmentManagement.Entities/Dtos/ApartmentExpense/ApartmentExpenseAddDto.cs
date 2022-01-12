using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.ApartmentExpense
{
    public class ApartmentExpenseAddDto:IDto
    {
        public int ApartmentId { get; set; }
        public int ExpenseId { get; set; }
    }
}
