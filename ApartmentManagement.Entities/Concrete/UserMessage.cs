using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class UserMessage : IEntity
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int MessageId { get; set; }
        public bool? IsNew { get; set; }
        public bool IsRead { get; set; }
        public bool IsActiveFuser { get; set; }
        public bool IsActiveToUser { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual User FromUser { get; set; }
        public virtual Message Message { get; set; }
        public virtual User ToUser { get; set; }
    }
}
