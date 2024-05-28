using Domain;
using My_Place_Backend.DTO.Auth;

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