using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Api.Interfaces
{
    public interface IIdentityRepository
    {
        string GenerateToken(UserSession user);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);

        Task<ApplicationUser?> FindUserById(string userId);

        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);

        Task<IdentityResult> EnsureRoleAsync(string roleName);

        Task<IdentityResult> FindOrCreateRole(string roleName);

        Task<ApplicationUser?> FindUserByEmailAsync(string email);


        Task<string> GeUserRoleAsync(string appUserid);
        Task<List<string>> GetUserRolesAsync(ApplicationUser user);

        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);

        Task<string> ForgotPasswordAsync(ApplicationUser user);
     
    }
}