using Domain.Models.Identity;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ISecurityService
    {
        Task CreateAccount(RegisterDTO userDto);

        Task LoginAccount(LoginDTO loginDTO);

        //Task<string?> GetUserNameAsync(string userId);

        //Task<bool> IsInRoleAsync(string userId, string role);

        //Task<bool> AuthorizeAsync(string userId, string policyName);

        //Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        //Task<Result> DeleteUserAsync(string userId);
    }
}