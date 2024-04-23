using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    using Domain;
    using Domain.Errors;
    using Domain.IRepositories;
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

            public AccountManagementService(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Result> ChangeAccountStatus(string userId, AccountStatusUpdateDTO statusUpdateDTO)
            {
                var user = _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                //user.AccountStatus = statusUpdateDTO.AccountStatus;
                //_userRepository.Update(user);

                return Result.Success();
            }

            public async Task<Result> UpdateAccount(string userId, AdminUpdateAccountDTO updateAccountDTO)
            {
                var user = _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                user.Name = updateAccountDTO.Name;
                user.Email = updateAccountDTO.Email;
                //_userRepository.Update(user);

                return Result.Success();
            }

            //public IQueryable<ApplicationUser> ListUsers(string searchTerm, string sortColumn, string sortOrder, int page, int pageSize)
            //{
            //    //return _userRepository.GetAll()
            //    //    .Where(u => u.Name.Contains(searchTerm))
            //    //    .OrderBy(sortColumn, sortOrder)
            //    //    .Skip((page - 1) * pageSize)
            //    //    .Take(pageSize);
            //}

            public async Task<Result> DeleteUser(string userId)
            {
                var user = _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                _userRepository.Remove(user);
                return Result.Success();
            }

            public IQueryable<ApplicationUser> ListUsers(string searchTerm, string sortColumn, string sortOrder, int page, int pageSize)
            {
                throw new NotImplementedException();
            }
        }
    }
}