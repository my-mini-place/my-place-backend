﻿namespace Api.Services
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
                    {Roles.User, GetUser }
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

                            break;
                        }
                    case (Roles.Administrator):
                        {
                            var administrator = await _administratorRepository.Get(u => u.UserId == userId);
                            _administratorRepository.Remove(administrator!);

                            break;
                        }
                    case (Roles.Repairman):
                    {
                            var repairman = await _repairmanRepository.Get(u => u.UserId == userId);
                            _repairmanRepository.Remove(repairman!);
                            break;
                        }
                    case (Roles.Manager):
                        {
                            var manager = await _managerRepository.Get(u => u.UserId == userId);
                            _managerRepository.Remove(manager!);
                            break;

                        }

                    default:
                        {
                            return Result.Failure(Error.NotFound("Roles", "That Role not exist"));

                        }
                }
                // dodawanie 
                switch(statusUpdateDTO.NewRole)
                {
                    case (Roles.User):
                        {

                            return Result.Failure(Error.Validation("New Role","New role cant be user"));
                            
                        }

                    case (Roles.Administrator):
                     {


                         break;
                     }
                    case (Roles.Manager):
                        {
                            if (statusUpdateDTO.StartWorkTime == null || statusUpdateDTO.EndWorkTime == null)
                            {
                                return Result.Failure(Error.Validation("StartWorkTime and EndWorkTime", "StartWorkTime and EndWorkTime must be provided"));
                            }
                            break;
                        }
                    case (Roles.Repairman):
                        {
                            if(statusUpdateDTO.StartWorkTime == null || statusUpdateDTO.EndWorkTime == null)
                            {
                                return Result.Failure(Error.Validation("StartWorkTime and EndWorkTime", "StartWorkTime and EndWorkTime must be provided"));
                            }
                            break;
                        }

                    case (Roles.Resident):
                        {

                            
                            if (statusUpdateDTO.ResidenceId == null)
                            {
                                return Result.Failure(Error.Validation("ResidenceId", "ResidenceId must be provided"));
                            }

                           var residence = await _residenceRepository.Get(u => u.ResidenceId == statusUpdateDTO.ResidenceId);
                            if (residence == null)
                            {
                                return Result.Failure(Error.NotFound("Residence", "Residence not found"));
                            }
                            Resident resident = new Resident()
                            {
                                
                                Guid= new Guid().ToString(),
                                ResidenceId = statusUpdateDTO.ResidenceId,
                                UserId = userId
                                

                            };
                           await  _residentRepository.Add(resident);
                           await _residenceRepository.Save();

                            break;
                        }
                }
                     



                _userRepository.Update(user);

                return Result.Success();
            }

            private bool IsValidRoleChange(string senderRole, string targetUserRole,string senderId, string targetId)
            {
                if (senderRole == Roles.Administrator)
                {
                    return true;
                }
                if (senderRole==Roles.Manager && targetUserRole!=Roles.Administrator)
                {
                    return true;
                }
                return senderRole == targetUserRole && senderId == targetId;
            }

            public async Task<Result> UpdateAccount(string senderId, UserUpdateDTO updateAccountDTO,string senderRole)
            {

                 
                var user = await _userRepository.Get(u => u.UserId.ToString() == updateAccountDTO.Id);
                if (user == null)
                {
                    return Result.Failure(Error.NotFound("User", "User not found"));
                }

                var userId = user.UserId;

                if(!IsValidRoleChange(senderRole,user.Role,senderId,updateAccountDTO.Id))
                {
                    return Result.Failure(Error.Conflict("Roles", "That role cant do that."));
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

                    default:
                        {
                              return Result.Failure(Error.NotFound("Roles", "That Role not exist"));

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

                                _residentRepository.Remove((await _residentRepository.Get(u => u.UserId == userId))!);
                                break;
                            }

                        case (Roles.Administrator):
                            {
                                _administratorRepository.Remove((await _administratorRepository.Get(u => u.UserId == userId))!);
                                break;
                            }
                        case (Roles.Manager):
                            {
                                _managerRepository.Remove((await _managerRepository.Get(u => u.UserId == userId))!);
                                break;
                            }
                        case (Roles.Repairman):
                            {
                                _repairmanRepository.Remove((await _repairmanRepository.Get(u => u.UserId == userId))!);
                                break;
                            }

                    }
                }
                catch(Exception)
                {
                    return Result.Failure(Error.Failure("DeleteUser", "Total failure."));
                }
                

                await _userRepository.Save();

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

            // tutaj dodac usuwanie starej roli
          

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

            public async Task<UserFullInfoDTO> GetUser(string UserId)
            {
                var User = await _userRepository.Get(item => item.UserId == UserId);

                // automaper
                UserFullInfoDTO result = new()
                {
                    Id = UserId,
                    //  Residence = _mapper.Map<ResidenceDTO>(GetResidentInfoResult.Residence),

                    Email = User.Email,
                    Status = User.Status,
                    Name = User.Name,
                    Surname = User.Surname,
                    PhoneNumber = User.PhoneNumber,
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

                PagedList<User> users = await _userRepository.GetAllUser(page, pageSize,null,null,sortColumn,sortOrder);

                List<UserDTO> userDTOs = users.Items.Select(u => _mapper.Map<UserDTO>(u)).ToList();

                PagedList<UserDTO> userDTOPage = new PagedList<UserDTO>(userDTOs, users.TotalCount, users.PageIndex, users.PageSize);

                return Result.Success(userDTOPage);
            }
        }
    }
}