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

        Task<Result<List<UserDTO>>> ListUsers(string? searchTerm, string? sortColumn, string? sortOrder, int? page, int? pageSize);

        Task<Result> DeleteUser(string userId);

        Task<Result> SetUserAvailability();

        Task<Result> UpdateUserRole();

        Task<Result<UserDTO>> GetUserInfo(string UserId);
    }
}