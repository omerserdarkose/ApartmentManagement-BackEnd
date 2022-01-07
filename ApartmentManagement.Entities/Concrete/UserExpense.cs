using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class UserExpense : IEntity
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int ExpenseId { get; set; }
        public bool DidPay { get; set; }
        public bool IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }
    }
}
