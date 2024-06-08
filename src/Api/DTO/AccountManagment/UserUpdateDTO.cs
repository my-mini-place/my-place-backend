using Api.DTO.Residence;

namespace My_Place_Backend.DTO.AccountManagment
{
    public class UserUpdateDTO
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }

        public string? ResidenceId { get; set; }
        public TimeSpan? StartWorkTime { get; set; }
        public TimeSpan? EndWorkTime { get; set; }
    }
}