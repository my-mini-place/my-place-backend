using Api.Interfaces;
using Domain;
using Domain.Errors;
using Domain.Models.Auth;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Auth.ServiceResponses;

namespace Api.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IIdentityRepository _identityRepository;

        public SecurityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<Result<Guid>> CreateAccount(RegisterDTO userDTO)
        {
            if (userDTO is null) return Result.Failure<Guid>(Error.Failure("userDTO", "User DTO is null"));

            // czy istnieje
            var userExists = await _identityRepository.FindUserByEmailAsync(userDTO.Email);
            if (userExists != null) return Result.Failure<Guid>(Error.Failure("UserExists", "User already registered"));
            // przerzuc to do mappera
            var newUser = new ApplicationUser
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                UserName = userDTO.Email
            };

            var createUserResult = await _identityRepository.CreateUserAsync(newUser, userDTO.Password);
            if (!createUserResult.Succeeded)
            {
                return Result.Failure<Guid>(Error.Failure(createUserResult.ToString(), createUserResult.Errors.FirstOrDefault()?.Description));
            }

            var roleResult = await _identityRepository.EnsureRoleAsync("User");
            if (!roleResult.Succeeded)
            {
                // return Result.Failure<Guid>(roleResult.Errors.FirstOrDefault()?.Description);
            }

            var addToRoleResult = await _identityRepository.AddUserToRoleAsync(newUser, "User");
            if (!addToRoleResult.Succeeded)
            {
                // return Result.Failure<Guid>(addToRoleResult.Errors.FirstOrDefault()?.Description);
            }

            return Result.Success(new Guid(newUser.Id));
        }

        public async Task<Result> forgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (forgotPassword == null)
            {
                return Result.Failure(Error.Failure("forgotPasswordDTO is null", "Login DTO is null"));
            }

            var user = await _identityRepository.FindUserByEmailAsync(forgotPasswordDTO.Email);
            if (user == null)
                return Result.Failure(Error.Failure("NotFound", "User not found"));

            var result = await _identityRepository.ForgotPasswordAsync(user);

            if (result == null)
            {
                return Result.Failure(Error.Failure("500", "Code generation dont work"));
            }
            // wyslanie emaila

            // gdy sie uda

            return Result.Success();
        }

        public async Task<Result> resetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            if (resetPasswordDTO == null)
                return Result.Failure<LoginResponseDTO>(Error.Failure("loginDTO", "Login DTO is null"));

            var user = await _identityRepository.FindUserByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
                return Result.Failure<LoginResponseDTO>(Error.Failure("NotFound", "User not found"));

            var result = await _identityRepository.ResetPasswordAsync(user, resetPasswordDTO.ResetCode, resetPasswordDTO.NewPassword);
            if (!result.Succeeded)
            {
                return Result.Failure(Error.Failure("ResetPasswordFailed", $"{result.Errors}"));
            }

            return Result.Success();
        }

        public async Task<Result<LoginResponseDTO>> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return Result.Failure<LoginResponseDTO>(Error.Failure("loginDTO", "Login DTO is null"));

            var user = await _identityRepository.FindUserByEmailAsync(loginDTO.Email);
            if (user == null)
                return Result.Failure<LoginResponseDTO>(Error.Failure("NotFound", "User not found"));

            var passwordValid = await _identityRepository.CheckPasswordAsync(user, loginDTO.Password);
            if (!passwordValid)
                return Result.Failure<LoginResponseDTO>(Error.Failure("InvalidCredentials", "Invalid email/password"));

            var roles = await _identityRepository.GetUserRolesAsync(user);
            var token = _identityRepository.GenerateToken(new UserSession(user.Id, user.UserName, user.Email, roles.FirstOrDefault()));

            return Result.Success(new LoginResponseDTO()
            {
                TokenType = "JTW",
                AccessToken = token,
                ExpiresIn = 3600,
            }); ;
        }
    }
}