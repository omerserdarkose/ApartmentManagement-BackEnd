using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class Apartment : IEntity
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public int? HirerId { get; set; }
        public short BlockId { get; set; }
        public int Floor { get; set; }
        public short DoorNumber { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }
    }
}
