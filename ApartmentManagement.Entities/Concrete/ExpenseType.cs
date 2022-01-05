using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class ExpenseType : IEntity, IInsert, IUpdate, IActive
    {
        public ExpenseType()
        {
            Expenses = new HashSet<Expense>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
