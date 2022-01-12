using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserClaim
{
    public class UserClaimAddDto:IDto
    {
        public int UserId { get; set; }
        public short ClaimId { get; set; }
    }
}
