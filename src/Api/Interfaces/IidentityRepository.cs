using Domain;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.ServiceResponses;

namespace Api.Interfaces
{
    public interface IIdentityRepository
    {
        string GenerateToken(UserSession user);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);

        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);

        Task<IdentityResult> EnsureRoleAsync(string roleName);

        Task<IdentityResult> FindOrCreateRole(string roleName);

        Task<ApplicationUser> FindUserByEmailAsync(string email);

        Task<List<string>> GetUserRolesAsync(ApplicationUser user);

        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);

        Task<string> ForgotPasswordAsync(ApplicationUser user);
    }
}