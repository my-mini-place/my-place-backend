using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    using AutoMapper;
    using Domain;
    using Domain.Errors;
    using Domain.IRepositories;
    using Domain.Models.Identity;
    using Domain.Repositories;
    using Domain.ValueObjects;
    using global::Api.DTO.AccountManagment;
    using global::Api.Interfaces;
    using Infrastructure.Data;
    using My_Place_Backend.DTO.AccountManagment;
    using System.Threading.Tasks;

    namespace Api.Services
    {
        public class AccountManagementService : IAccountManagementService
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IIdentityRepository _identityRepository;

            public AccountManagementService(IUserRepository userRepository, IMapper mapper, IIdentityRepository identityRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _identityRepository = identityRepository;
            }

            public async Task<Result> ChangeAccountStatus(string userId, AccountStatusUpdateDTO statusUpdateDTO)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                if (statusUpdateDTO.AccountStatus == AccountStatus.Rejected && statusUpdateDTO.NewRole != null)
                    return Result.Failure(Error.Conflict("AccountStatusUpdate", "Account cant be rejected and have new role"));

                if (user.Status == statusUpdateDTO.AccountStatus)
                {
                    return Result.Failure(Error.Conflict("AccountStatus", "New status cant be the same as old one"));
                }

                user.Status = statusUpdateDTO.AccountStatus;

                _userRepository.Update(user);

                return Result.Success();
            }

            public async Task<Result> UpdateAccount(string userId, AdminUpdateAccountDTO updateAccountDTO)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                // przypisanie danychz updateAccountDTO

                // jeszcze to zmien w identity ten email ok dasz rade

                _userRepository.Update(user);

                return Result.Success();
            }

            // dodaj usuwanie z identiyy repisotry
            public async Task<Result> DeleteUser(string userId)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                _userRepository.Remove(user);

                return Result.Success();
            }

            public Task<Result> SetUserAvailability()
            {
                throw new NotImplementedException();
            }

            // tutaj dodac usuwanie starej roli
            public async Task<Result> UpdateUserRole(string UserId, string Role)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == UserId);
                if (user == null) { return Result.Failure<UserDTO>(Error.NotFound("User", "User not found")); }

                var appuser = await _identityRepository.FindUserByEmailAsync(user.Email);

                var result = await _identityRepository.AddUserToRoleAsync(appuser!, Role);
                if (!result.Succeeded)
                {
                }

                return Result.Success();
            }

            public async Task<Result<UserDTO>> GetUserInfo(string UserId)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == UserId);
                if (user == null)
                {
                    return Result.Failure<UserDTO>(Error.NotFound("User", "User not found"));
                }

                var userDTO = _mapper.Map<UserDTO>(user);
                return Result.Success(userDTO);
            }

            public async Task<Result<List<UserDTO>>> ListUsers(string? searchTerm, string? sortColumn, string? sortOrder, int? page, int? pageSize)
            {
                List<User> user = await _userRepository.GetAll();

                return Result.Success(_mapper.Map<List<UserDTO>>(user));
            }
        }
    }
}