using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.User
{
    public class UserAddDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? IdentityNo { get; set; }
        public string[] LicensePlate { get; set; }
        public int ApartmentId { get; set; }
        public bool IsHirer { get; set; }
    }
}