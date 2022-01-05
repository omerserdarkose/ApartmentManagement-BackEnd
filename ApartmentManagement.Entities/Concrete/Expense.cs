using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class Expense : IEntity, IInsert, IUpdate, IActive
    {
        public Expense()
        {
            UserExpenses = new HashSet<UserExpense>();
        }

        public int Id { get; set; }
        public short TypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual ExpenseType Type { get; set; }
        public virtual ICollection<UserExpense> UserExpenses { get; set; }
    }
}
