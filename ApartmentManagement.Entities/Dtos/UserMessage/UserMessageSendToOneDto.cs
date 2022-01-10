using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.UserMessage
{
    public class UserMessageSendToOneDto:IDto
    {
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public int RecipientId { get; set; }
    }
}