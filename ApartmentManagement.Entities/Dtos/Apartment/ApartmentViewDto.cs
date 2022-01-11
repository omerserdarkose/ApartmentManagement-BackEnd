using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Apartment
{
    public class ApartmentViewDto:IDto
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public int? HirerId { get; set; }
        public string? HirerName { get; set; }
        public short BlockId { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public short DoorNumber { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
    }
}
