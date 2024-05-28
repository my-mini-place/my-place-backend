using Api.DTO.Residence;
using Domain.ValueObjects;

namespace Api.DTO.AccountManagment
{
    public class UserFullInfoDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public ResidenceDTO? Residence { get; set; }

        public TimeSpan? StartWorkTime { get; set; }
        public TimeSpan? EndWorkTime { get; set; }

        public string? BlockName { get; set; }
        public string Role { get; set; }
        public AccountStatus Status { get; set; }
    }
}