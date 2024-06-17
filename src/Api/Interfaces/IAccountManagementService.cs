using Api.DTO.AccountManagment;
using Domain;
using My_Place_Backend.DTO.AccountManagment;

namespace Api.Interfaces
{
    public interface IAccountManagementService
    {
        Task<Result> ChangeAccountStatus(string userId, AccountStatusUpdateDTO statusUpdateDTO);

        Task<Result> UpdateAccount(string userId, UserUpdateDTO updateAccountDTO,string senderRole);

        Task<Result<PagedList<UserDTO>>> ListUsers(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder);

        Task<Result> DeleteUser(string userId);

        Task<Result> SetUserAvailability();

       

        Task<Result<UserFullInfoDTO>> GetUserInfo(string userId);
    }
}