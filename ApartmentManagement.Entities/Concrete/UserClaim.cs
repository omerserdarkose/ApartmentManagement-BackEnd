using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class UserClaim : IEntity, IInsert, IUpdate, IActive
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public short ClaimId { get; set; }
        public bool IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual Claim Claim { get; set; }
        public virtual User User { get; set; }
    }
}
