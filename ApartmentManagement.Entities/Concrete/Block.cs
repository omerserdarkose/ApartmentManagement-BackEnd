using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApartmentManagement.Entities.Concrete
{
    public partial class Block : IEntity
    {
        public Block()
        {
            Apartments = new HashSet<Apartment>();
        }

        public short Id { get; set; }
        public string Letter { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
