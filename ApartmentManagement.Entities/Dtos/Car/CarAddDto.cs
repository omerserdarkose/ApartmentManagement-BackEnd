using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Car
{
    public class CarAddDto:IDto
    {
        public int UserId { get; set; }
        public string LicensePlate { get; set; }
    }
}
