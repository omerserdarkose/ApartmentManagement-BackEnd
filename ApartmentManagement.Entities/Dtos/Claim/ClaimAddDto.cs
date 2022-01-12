using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Claim
{
    public class ClaimAddDto:IDto
    {
        public string Name { get; set; }

    }
}
