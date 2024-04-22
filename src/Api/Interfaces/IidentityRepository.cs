using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Auth.ServiceResponses;

namespace Api.Interfaces
{
    public interface IIdentityRepository
    {
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);

        Task<GeneralResponse> CreateAccount(RegisterDTO userDTO);
    }
}