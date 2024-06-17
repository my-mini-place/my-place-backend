using Domain.ValueObjects;

namespace Api.DTO.AccountManagment
{
    public class AccountStatusUpdateDTO
    {
        public AccountStatus AccountStatus { get; set; }

        public string? NewRole { get; set; }

        public string? StartWorkTime { get; set; }
        public string? EndWorkTime { get; set; }

        public string? ResidenceId { get; set;  }
    }
}