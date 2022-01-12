using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserClaim
{
    public class UserClaimUpdateDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public short ClaimId { get; set; }
    }
}
