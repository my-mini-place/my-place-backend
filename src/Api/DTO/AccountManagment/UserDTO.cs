using Domain.ValueObjects;

namespace My_Place_Backend.DTO.AccountManagment
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Password { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int Floor { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }
        public AccountStatus Status { get; set; }
    }
}