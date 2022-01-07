using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.User
{
    public class UserIdentityDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}