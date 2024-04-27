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

            public AccountManagementService(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<Result> ChangeAccountStatus(string userId, AccountStatusUpdateDTO statusUpdateDTO)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                // sprawdzenie czy ma role admina nie zarządcy

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

            public Task<Result> UpdateUserRole()
            {
                throw new NotImplementedException();
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