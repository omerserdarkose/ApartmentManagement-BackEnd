using System.Reflection;
using ApartmentManagement.Core.Entities;
using Microsoft.AspNetCore.Diagnostics;

namespace ApartmentManagement.Entities.Dtos.User
{
    public class UserViewDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Block { get; set; }
        public short DoorNumber { get; set; }
        public string Title { get; set; }
}
}