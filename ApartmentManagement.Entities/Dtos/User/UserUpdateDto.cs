using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.User
{
    public class UserUpdateDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}