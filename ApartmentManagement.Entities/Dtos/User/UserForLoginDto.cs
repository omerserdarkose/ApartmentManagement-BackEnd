using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.User
{
    public class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
