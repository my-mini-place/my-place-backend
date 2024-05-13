using Domain.ValueObjects;

namespace My_Place_Backend.DTO.AccountManagment
{
    public class AdminUpdateAccountDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ResidenceID { get; set; }

        public AccountStatus? AccountStatus { get; set; }
    }
}