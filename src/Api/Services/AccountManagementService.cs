namespace Api.Services
{
    using AutoMapper;
    using Domain;
    using Domain.Errors;
    using Domain.IRepositories;
    using Domain.Models.Identity;
    using Domain.ValueObjects;
    using global::Api.DTO.AccountManagment;
    using global::Api.Interfaces;
    using My_Place_Backend.DTO.AccountManagment;
    using System.Threading.Tasks;

    namespace Api.Services
    {
        public class AccountManagementService : IAccountManagementService
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IIdentityRepository _identityRepository;

            private readonly Dictionary<string, Func<string, Task<UserFullInfoDTO>>> _userInfoSwitch;

            public AccountManagementService(IUserRepository userRepository, IMapper mapper, IIdentityRepository identityRepository, Dictionary<string, Func<string, Task<UserFullInfoDTO>>> _userInfoSwitch)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _identityRepository = identityRepository;

                _userInfoSwitch = new Dictionary<string, Func<string, Task<UserFullInfoDTO>>>()
            {
                {Roles.Manager, GetManagerInfo },
                {Roles.Administrator, GetAdminInfo },
                 {Roles.Manager, GetManagerInfo },
                {Roles.Repairman, GetRepairManInfo },
            };
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

            public async Task<Result<UserFullInfoDTO>> GetUserInfo(string userId, string userRole)
            {
                var user = await _userRepository.Get(u => u.UserId == userId);
                if (user == null)
                {
                    return Result.Failure<UserFullInfoDTO>(Error.NotFound("User", "User not found"));
                }

                ///stara
                ///

                try
                {
                    var UserFullInfodto = await _userInfoSwitch[userRole](userId);

                    return Result.Success(UserFullInfodto);
                }
                catch (Exception)
                {
                    return Result.Failure<UserFullInfoDTO>(Error.Failure("GetUserData", "Total failure."));
                }

                //var user = await _userRepository.Get(u => u.UserId.ToString() == userId);
                //if (user == null)
                //{
                //    return Result.Failure<UserDTO>(Error.NotFound("User", "User not found"));
                //}

                //var userDTO = _mapper.Map<UserDTO>(user);
                //return Result.Success(userDTO);

             
            }

            public async Task<UserFullInfoDTO> GetAdminInfo(string UserId)
            {
                throw new NotImplementedException();
            }

            public async Task<UserFullInfoDTO> GetRepairManInfo(string UserId)
            {
                throw new NotImplementedException();
            }

            public async Task<UserFullInfoDTO> GetResidentInfo(string UserId)
            {
                throw new NotImplementedException();
            }

            public async Task<UserFullInfoDTO> GetManagerInfo(string UserId)
            {
                throw new NotImplementedException();
            }

            public async Task<Result<PagedList<UserDTO>>> ListUsers(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder)
            {
                PagedList<User> users = await _userRepository.GetAll(page, pageSize);

                List<UserDTO> userDTOs = users.Items.Select(u => _mapper.Map<UserDTO>(u)).ToList();

                PagedList<UserDTO> userDTOPage = new PagedList<UserDTO>(userDTOs, users.TotalCount, users.PageIndex, users.PageSize);

                return Result.Success(userDTOPage);
            }
        }
    }
}