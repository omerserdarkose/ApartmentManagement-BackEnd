using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Expense
{
    public class ExpenseViewDto:IDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int PaidCount { get; set; }
        public int UnPaidCount { get; set; }
    }
}
