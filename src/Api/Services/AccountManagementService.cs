namespace Api.Services
{
    using AutoMapper;
    using Domain;
    using Domain.Errors;
    using Domain.IRepositories;
    using Domain.Models.Identity;
    using Domain.ValueObjects;
    using global::Api.DTO.AccountManagment;
    using global::Api.DTO.Residence;
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
            private readonly IResidentRepository _residentRepository;
            private readonly IRepairmanRepository _repairmanRepository;
            private readonly IAdministratorRepository _administratorRepository;
            private readonly IManagerRepository _managerRepository;
            private readonly IResidenceRepository _residenceRepository;

            private readonly Dictionary<string, Func<string, Task<UserFullInfoDTO>>> _userInfoSwitch;

            public AccountManagementService(IUserRepository userRepository, IMapper mapper, IIdentityRepository identityRepository, IResidentRepository residentRepository,IAdministratorRepository administratorRepository,IManagerRepository managerRepository,IRepairmanRepository repairmanRepository, IResidenceRepository residenceRepository)
            {
                _residenceRepository = residenceRepository;
                _repairmanRepository = repairmanRepository;
                _administratorRepository = administratorRepository;
                _managerRepository= managerRepository;
                _residentRepository = residentRepository;
                _userRepository = userRepository;
                _mapper = mapper;
                _identityRepository = identityRepository;

                _userInfoSwitch = new Dictionary<string, Func<string, Task<UserFullInfoDTO>>>()
            {
                {Roles.Manager, GetManagerInfo },
                {Roles.Administrator, GetAdminInfo },
                 {Roles.Resident, GetResidentInfo },
                {Roles.Repairman, GetRepairManInfo },
            };
                _residentRepository = residentRepository;
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

            public async Task<Result> UpdateAccount(string userId, UserUpdateDTO updateAccountDTO,string senderRole)
            {
                var user = await _userRepository.Get(u => u.UserId.ToString() == userId);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                user.Surname = updateAccountDTO.Surname ?? user.Surname;
                user.Name = updateAccountDTO.Name ?? user.Name;
                user.PhoneNumber = updateAccountDTO.PhoneNumber ?? user.PhoneNumber;
                user.Email = updateAccountDTO.Email ?? user.Email;

                 _userRepository.Update(user);

                // da sie to zamienic na słownik itd fabryke ale to tylko 3 opcje wiec nei ma sensu  ewentualnie admina/manager/repairmana/residenent servisy
                switch (user.Role)
                {
                    case (Roles.User):
                       
                       if(updateAccountDTO.ResidenceId!=null)
                        {
                            return Result.Failure(Error.Conflict("UpdateAccount", "User cant have residence id"));
                        }

                      

                        _userRepository.Update(user);


                        break;

                    case (Roles.Resident):
                        {

                           

                            var resident = await _residentRepository.Get(u => u.UserId == userId);
                            if (resident != null)
                            {
                                resident.ResidenceId = updateAccountDTO.ResidenceId ?? resident.ResidenceId;
                                _residentRepository.Update(resident);
                            }
                            else
                            {
                                return Result.Failure(Error.NotFound("Resident", "Resident not found"));
                            }

                            break;
                        }

                    case (Roles.Administrator):
                        {

                            
                            break;
                        }
                    case (Roles.Manager):
                        {
                            var manager = await _managerRepository.Get(u => u.UserId == userId);
                            if (manager != null)
                            {
                                manager.StartWorkTime = updateAccountDTO.StartWorkTime ?? manager.StartWorkTime;
                                manager.EndWorkTime = updateAccountDTO.EndWorkTime ?? manager.EndWorkTime;

                               _managerRepository.Update(manager);
                            }
                            else
                            {
                                return Result.Failure(Error.NotFound("Resident", "Resident not found"));
                            }

                            break;
                        }
                    case (Roles.Repairman):
                        {

                            var Repairman = await _repairmanRepository.Get(u => u.UserId == userId);
                            if (Repairman != null)
                            {
                                Repairman.StartWorkTime = updateAccountDTO.StartWorkTime ?? Repairman.StartWorkTime;
                                Repairman.EndWorkTime = updateAccountDTO.EndWorkTime ?? Repairman.EndWorkTime;

                                _repairmanRepository.Update(Repairman);
                            }
                            else
                            {
                                return Result.Failure(Error.NotFound("Resident", "Resident not found"));
                            }

                            break;
                        }

                }

                

                // czy ten zapis robi sie dla wszystkich entitiy czy tylko dla jednego, raczej dla kazdego bo dziala na db a nie dbsecie
                await _residenceRepository.Save();
               await _userRepository.Save();

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

                var userRole = user.Role;

                try
                {
                    switch (user.Role)
                    {
                        case (Roles.User):
                            _userRepository.Remove(user);
                            // usun z identity repository 

                            break;

                        case (Roles.Resident):
                            {

                                _residentRepository.Remove(await _residentRepository.Get(u => u.UserId == userId));
                                break;
                            }

                        case (Roles.Administrator):
                            {
                                _administratorRepository.Remove(await _administratorRepository.Get(u => u.UserId == userId));
                                break;
                            }
                        case (Roles.Manager):
                            {
                                _managerRepository.Remove(await _managerRepository.Get(u => u.UserId == userId));
                                break;
                            }
                        case (Roles.Repairman):
                            {
                                _repairmanRepository.Remove(await _repairmanRepository.Get(u => u.UserId == userId));
                                break;
                            }

                    }
                }
                catch(Exception)
                {
                    return Result.Failure(Error.Failure("DeleteUser", "Total failure."));
                }
                

                _userRepository.Save();

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

            public async Task<Result<UserFullInfoDTO>> GetUserInfo(string userId)
            {
                var user = await _userRepository.Get(u => u.UserId == userId);
                if (user == null)
                {
                    return Result.Failure<UserFullInfoDTO>(Error.NotFound("User", "User not found"));
                }

                var userIdentity = await _identityRepository.FindUserById(userId);

                if(userIdentity==null)
                {
                    return Result.Failure<UserFullInfoDTO>(Error.NotFound("UserApp", "UserApp not found"));
                }

                string userRole = user.Role;



                try
                {
                    var UserFullInfodto = await _userInfoSwitch[userRole](userId);
                    UserFullInfodto.Role=userRole;

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
                var GetResidentInfoResult = await _administratorRepository.Get(u => u.UserId == UserId, "User");

                // automaper
                UserFullInfoDTO result = new()
                {
                    Id = UserId,
                    //  Residence = _mapper.Map<ResidenceDTO>(GetResidentInfoResult.Residence),
                   
                    Email = GetResidentInfoResult.User.Email,
                    Status = GetResidentInfoResult.User.Status,
                    Name = GetResidentInfoResult.User.Name,
                    Surname = GetResidentInfoResult.User.Surname,
                    PhoneNumber = GetResidentInfoResult.User.PhoneNumber,
                };

                return result;
            }

            public async Task<UserFullInfoDTO> GetRepairManInfo(string UserId)
            {
                var GetResidentInfoResult = await  _repairmanRepository.Get(u => u.UserId == UserId, "User");

                 // add automaper
                UserFullInfoDTO result = new()
                {
                    Id = UserId,
                   // Role = Roles.Resident,
                    Email = GetResidentInfoResult.User.Email,
                    Status = GetResidentInfoResult.User.Status,
                    Name = GetResidentInfoResult.User.Name,
                    Surname = GetResidentInfoResult.User.Surname,
                    PhoneNumber = GetResidentInfoResult.User.PhoneNumber,
                    EndWorkTime = GetResidentInfoResult.EndWorkTime,
                    StartWorkTime = GetResidentInfoResult.StartWorkTime,

                };

                return result;
            }

            public async Task<UserFullInfoDTO> GetResidentInfo(string UserId)
            {

                var GetResidentInfoResult = await _residentRepository.Get(u => u.UserId == UserId,"Residence,User");

                 // add automaper
                UserFullInfoDTO result = new()
                {
                    Id = UserId,
                    Residence = _mapper.Map<ResidenceDTO>(GetResidentInfoResult.Residence),
                //    Role = Roles.Resident,
                    Email = GetResidentInfoResult.User.Email,
                    Status = GetResidentInfoResult.User.Status,
                    Name = GetResidentInfoResult.User.Name,
                    Surname = GetResidentInfoResult.User.Surname,
                    PhoneNumber = GetResidentInfoResult.User.PhoneNumber,
                    
                    
                };

                return result;

               
               

            }

            public async Task<UserFullInfoDTO> GetManagerInfo(string UserId)
            {
                var GetResidentInfoResult = await _managerRepository.Get(u => u.UserId == UserId, "User");

                 // add automaper
                UserFullInfoDTO result = new()
                {
                    Id = UserId,
                   // Residence = _mapper.Map<ResidenceDTO>(GetResidentInfoResult.Residence),
              //      Role = Roles.Resident,
                    Email = GetResidentInfoResult.User.Email,
                    Status = GetResidentInfoResult.User.Status,
                    Name = GetResidentInfoResult.User.Name,
                    Surname = GetResidentInfoResult.User.Surname,
                    PhoneNumber = GetResidentInfoResult.User.PhoneNumber,
                    EndWorkTime = GetResidentInfoResult.EndWorkTime,
                    StartWorkTime = GetResidentInfoResult.StartWorkTime,


                };

                return result;
            }

            public async Task<Result<PagedList<UserDTO>>> ListUsers(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder)
            {

                if (page <= 0||pageSize<=0)
                {
                    return Result.Failure<PagedList<UserDTO>>(Error.Validation("page and pageSize", "Page and pagesize must be > 0."));


                }

                PagedList<User> users = await _userRepository.GetAll(page, pageSize);

                List<UserDTO> userDTOs = users.Items.Select(u => _mapper.Map<UserDTO>(u)).ToList();

                PagedList<UserDTO> userDTOPage = new PagedList<UserDTO>(userDTOs, users.TotalCount, users.PageIndex, users.PageSize);

                return Result.Success(userDTOPage);
            }
        }
    }
}