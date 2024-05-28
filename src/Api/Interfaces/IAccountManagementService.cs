using Api.DTO.AccountManagment;
using Domain;
using Domain.Models.Identity;
using Infrastructure.Data;
using My_Place_Backend.DTO.AccountManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IAccountManagementService
    {
        Task<Result> ChangeAccountStatus(string userId, AccountStatusUpdateDTO statusUpdateDTO);

        Task<Result> UpdateAccount(string userId, AdminUpdateAccountDTO updateAccountDTO);

        Task<Result<PagedList<UserDTO>>> ListUsers(int page, int pageSize,string? searchTerm, string? sortColumn, string? sortOrder );

        Task<Result> DeleteUser(string userId);

        Task<Result> SetUserAvailability();

        Task<Result> UpdateUserRole(string userId, string newRole);

        Task<Result<UserFullInfoDTO>> GetUserInfo(string userId,string userRole);
    }
}