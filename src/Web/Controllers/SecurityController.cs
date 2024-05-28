using Api.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Place_Backend.DTO.Auth;
using Serilog;
using Web.Extensions;

namespace My_Place_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private ISecurityService _SecurityService;

        public SecurityController(ISecurityService SecurityService)
        {
            _SecurityService = SecurityService;
        }

        [HttpPost("register")]
        public async Task<object> Register(RegisterDTO userDTO)
        {
            Result<Guid> response = await _SecurityService.CreateAccount(userDTO);
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok(response.Value);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            Result<LoginResponseDTO> response = await _SecurityService.LoginAccount(loginDTO);

            Log.Information($"Wynik operacji logowania: {response.IsSuccess}");

            if (response.IsFailure)
            {
                return BadRequest(response.Error);
            }
            return Ok(response.Value);
        }

        [HttpPost("forgotPassword")]
        public async Task<object> forgotPassword(ForgotPasswordDTO ForgotPasswordDTO)
        {
            Result response = await _SecurityService.forgotPassword(ForgotPasswordDTO);
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok();
        }

        [HttpPost("resetPassword")]
        public async Task<object> resetPassword(ResetPasswordDTO ResetPasswordDTO)
        {
            Result response = await _SecurityService.resetPassword(ResetPasswordDTO);
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok();
        }
    }
}