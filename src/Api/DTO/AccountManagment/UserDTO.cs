using Api.DTO.AccountManagment;
using Api.DTO.Residence;
using Domain.ValueObjects;
using System.Data;

namespace My_Place_Backend.DTO.AccountManagment
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Role { get; set; } = null!;

        public AccountStatus Status { get; set; }

    }
}