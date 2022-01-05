using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class Message : IEntity, IInsert, IUpdate
    {
        public Message()
        {
            UserMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message1 { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
