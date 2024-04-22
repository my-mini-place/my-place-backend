using Api.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;

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
        public async Task<IActionResult> Register(RegisterDTO userDTO)
        {
            await _SecurityService.CreateAccount(userDTO);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            //var response = await _SecurityService.LoginAccount(loginDTO);
            return Ok();
        }
    }
}