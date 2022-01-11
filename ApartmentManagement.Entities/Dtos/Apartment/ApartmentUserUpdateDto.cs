using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Apartment
{
    public class ApartmentUserUpdateDto:IDto
    {
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public bool IsHirer { get; set; }
        public bool IsResident { get; set; }
    }
}
