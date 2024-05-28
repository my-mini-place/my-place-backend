using Domain.ValueObjects;

namespace Api.DTO.AccountManagment
{
    public class AccountStatusUpdateDTO
    {
        public AccountStatus AccountStatus { get; set; }
        public string? NewRole { get; set; }
    }
}