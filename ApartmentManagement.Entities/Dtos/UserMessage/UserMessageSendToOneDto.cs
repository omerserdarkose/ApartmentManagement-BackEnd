using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Message
{
    public class MessageSendToOneDto:IDto
    {
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public int RecipientId { get; set; }
    }
}