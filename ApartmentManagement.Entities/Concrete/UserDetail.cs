using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class UserDetail : IEntity
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNo { get; set; }
        public bool? IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
