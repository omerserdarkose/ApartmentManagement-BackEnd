using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserMessage
{
    public class UserMessageSendToAllDto:IDto
    {
        public string Subject { get; set; }
        public string MessageText { get; set; }
    }
}
