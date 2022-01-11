using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Apartment
{
    public class ApartmentUpdateDto:IDto
    {
        public int Id { get; set; }
        public short BlockId { get; set; }
        public int Floor { get; set; }
        public short DoorNumber { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
    }
}
