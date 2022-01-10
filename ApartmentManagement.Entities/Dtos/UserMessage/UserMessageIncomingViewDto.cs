using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserMessage
{
    public class UserMessageIncomingViewDto:IDto
    {
        public int Id { get; set; }
        public string FromUserName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageText { get; set; }
        public bool IsNew { get; set; }
        public bool IsRead { get; set; }
        public bool IsActive { get; set; }
        public DateTime MessageDate { get; set; }
        public int FromUserId { get; set; }
        public string FromUserClaim { get; set; }
        public string FromUserBlock { get; set; }
        public int FromUserDoorNumber { get; set; }
    }
}
