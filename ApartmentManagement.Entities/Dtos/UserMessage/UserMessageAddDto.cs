using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserMessage
{
    public class UserMessageAddDto:IDto
    {
        public int MessageId{ get; set; }
        public int ToUserId { get; set; }
    }
}
