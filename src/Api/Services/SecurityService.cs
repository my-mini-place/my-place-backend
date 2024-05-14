using Api.Interfaces;
using Domain;
using Domain.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Domain.Entities.ServiceResponses;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using AutoMapper;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IEmailSender _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SecurityService(IIdentityRepository identityRepository, IEmailSender emailService, IUserRepository userRepository, IMapper maper)
        {
            _identityRepository = identityRepository;
            _emailService = emailService;
            _userRepository = userRepository;
            _mapper = maper;
        }

        public async Task<Result<Guid>> CreateAccount(RegisterDTO userDTO)
        {
            if (userDTO is null) return Result.Failure<Guid>(Error.Failure("userDTO", "User DTO is null"));

            // czy istnieje
            var userExists = await _identityRepository.FindUserByEmailAsync(userDTO.Email);
            if (userExists != null) return Result.Failure<Guid>(Error.Failure("UserExists", "User already registered"));

            Guid newUserId = Guid.NewGuid();

            var newUser = new ApplicationUser
            {
                UserId = newUserId,
                Name = userDTO.Name,
                Email = userDTO.Email,
                UserName = userDTO.Email
            };

            var UserInfo = _mapper.Map<User>(userDTO);

            UserInfo.UserId = newUserId;

            var createUserResult = await _identityRepository.CreateUserAsync(newUser, userDTO.Password);
            if (!createUserResult.Succeeded)
            {
                return Result.Failure<Guid>(Error.Failure(createUserResult.ToString(), createUserResult.Errors.FirstOrDefault()!.Description));
            }

            // dodanie informacji o userze do tabeli user
            await _userRepository.Add(UserInfo);

            var roleResult = await _identityRepository.EnsureRoleAsync(Roles.User);
            if (!roleResult.Succeeded)
            {
                return Result.Failure<Guid>(Error.Failure("Role", "Error to ensure that role exist"));
            }

            var addToRoleResult = await _identityRepository.AddUserToRoleAsync(newUser, Roles.User);
            if (!addToRoleResult.Succeeded)
            {
                return Result.Failure<Guid>(Error.Failure("Role", "Error to add user Role "));
            }

            return Result.Success(newUserId);
        }

        public async Task<Result<string>> forgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (forgotPassword == null)
            {
                return Result.Failure<string>(Error.Failure("forgotPasswordDTO is null", "Login DTO is null"));
            }

            var user = await _identityRepository.FindUserByEmailAsync(forgotPasswordDTO.Email);
            if (user == null)
                return Result.Failure<string>(Error.Failure("NotFound", "User not found"));

            var result = await _identityRepository.ForgotPasswordAsync(user);

            if (result == null)
            {
                return Result.Failure<string>(Error.Failure("500", "Code generation dont work"));
            }

            var subject = "Resetowanie hasła";
            var message = $"Twój kod do resetowania hasła to: {result}";
            var sendEmailResult = await _emailService.SendEmailAsync(forgotPasswordDTO.Email, subject, message);

            //if (sendEmailResult.IsSuccess)
            //{
            return Result.Success(result);
            //}
            //else
            //{
            //    return Result.Failure<string>(Error.Failure("Email", "Email Error"));
            //}
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

        //public async Task<Result<List<string>>> GetUserRoles(string UserId)
        //{
        //    //var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    //if (identity != null)
        //    //{
        //    //    IEnumerable<Claim> claims = identity.Claims;
        //    //    // or
        //    //    identity.FindFirst("ClaimName").Value;

        //    //}
        //}

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