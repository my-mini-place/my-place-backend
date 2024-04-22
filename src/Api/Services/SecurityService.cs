using Api.Interfaces;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IIdentityRepository _identityRepository;

        public SecurityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task CreateAccount(RegisterDTO userDTO)
        {
        }

        public Task LoginAccount(LoginDTO loginDTO)
        {
            return _identityRepository.LoginAccount(loginDTO);
        }
    }
}