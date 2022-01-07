using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.User
{
    public class UserClaimsViewDto:IDto
    {
        public short Id { get; set; }
        public string ClaimName { get; set; }
    }
}