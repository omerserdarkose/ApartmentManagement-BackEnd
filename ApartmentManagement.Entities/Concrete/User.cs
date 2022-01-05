using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class User : IEntity
    {
        public User()
        {
            Apartments = new HashSet<Apartment>();
            Cars = new HashSet<Car>();
            UserClaims = new HashSet<UserClaim>();
            UserMessageFromUsers = new HashSet<UserMessage>();
            UserMessageToUsers = new HashSet<UserMessage>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool? IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserMessage> UserMessageFromUsers { get; set; }
        public virtual ICollection<UserMessage> UserMessageToUsers { get; set; }
    }
}
