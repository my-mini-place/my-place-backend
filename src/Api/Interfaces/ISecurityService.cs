using Domain;
using Domain.Models.Identity;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ISecurityService
    {
        Task<Result<Guid>> CreateAccount(RegisterDTO userDto);

        Task<Result<LoginResponseDTO>> LoginAccount(LoginDTO loginDTO);

        Task<Result<string>> forgotPassword(ForgotPasswordDTO forgotPasswordDTO);

        Task<Result> resetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}