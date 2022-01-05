using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class Apartment : IEntity, IInsert, IUpdate
    {
        public Apartment()
        {
            UserExpenses = new HashSet<UserExpense>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public short BlockId { get; set; }
        public int Floor { get; set; }
        public short Number { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public bool IsHirer { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual Block Block { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserExpense> UserExpenses { get; set; }
    }
}
