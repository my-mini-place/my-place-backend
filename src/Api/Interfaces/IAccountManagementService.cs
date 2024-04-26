using Api.DTO.AccountManagment;
using Domain;
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

        List<ApplicationUser> ListUsers(string searchTerm, string sortColumn, string sortOrder, int page, int pageSize);

        Task<Result> DeleteUser(string userId);

        Task<Result> SetUserAvailability();

        Task<Result> UpdateUserRole();

        Task<Result> GetUserInfo(string UserId);
    }
}