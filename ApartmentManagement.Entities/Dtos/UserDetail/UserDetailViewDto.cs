using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserDetail
{
    public class UserDetailViewDto:IDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNo { get; set; }
    }
}
