using Domain.ValueObjects;

namespace Api.DTO.AccountManagment
{
    public class AccountStatusUpdateDTO
    {
        public AccountStatus? AccountStatus { get; set; }
        public string? NewRole { get; set; }

        public string? ResidenceId { get; set; }
        public TimeSpan? StartWorkTime { get; set; }
        public TimeSpan? EndWorkTime { get; set; }

    }
}