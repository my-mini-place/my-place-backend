using Domain.Models.Identity;
using System.Data;
using System.IO;

namespace My_Place_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Api.Interfaces;

    using global::My_Place_Backend.DTO.AccountManagment;
    using Microsoft.AspNetCore.Authorization;
    using Api.DTO.AccountManagment;
    using Domain.Models.Identity;
    using Microsoft.AspNetCore.Identity;

    using Web.Authorization;
    using global::My_Place_Backend.Authorization;

    namespace My_Place_Backend.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AccountManagementController : ControllerBase
        {
            private readonly IAccountManagementService _accountManagementService;

            public AccountManagementController(IAccountManagementService accountManagementService)
            {
                _accountManagementService = accountManagementService;
            }

            [HttpPatch("changeAccountStatus/{userId}")]
            public async Task<IActionResult> ChangeAccountStatus(string userId, [FromBody] AccountStatusUpdateDTO statusUpdateDTO)
            {
                var result = await _accountManagementService.ChangeAccountStatus(userId, statusUpdateDTO);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpPatch("updateAccount/{userId}")]
            public async Task<IActionResult> UpdateAccount(string userId, [FromBody] AdminUpdateAccountDTO updateAccountDTO)
            {
                var result = await _accountManagementService.UpdateAccount(userId, updateAccountDTO);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpGet("users")]
            public async Task<IActionResult> ListUsers(string? searchTerm, string? sortColumn, string? sortOrder, int? page, int? pageSize)
            {
                var users = await _accountManagementService.ListUsers(searchTerm, sortColumn, sortOrder, page, pageSize);
                return Ok(users.Value);
            }

            [HttpDelete("deleteUser/{userId}")]
            [Authorize("IsAdmin")]
            public async Task<IActionResult> DeleteUser(string userId)
            {
                var result = await _accountManagementService.DeleteUser(userId);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpGet("getUserInfo/{userId}")]
            [Authorize("IsAny")]
            public async Task<IActionResult> GetUserInfo()
            {

                string userId = User.GetUserId().ToString();
                string userRole = User.GetUserRole();

                var result = await _accountManagementService.GetUserInfo(userId,userRole);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok(result.Value);
            }

            [HttpPatch("updateUserRole/{userId}")]
            [Authorize("")]
            public async Task<IActionResult> UpdateUserRole(string userId, [FromBody] string role)
            {
                var result = await _accountManagementService.UpdateUserRole(userId, role);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpPatch("setUserAvailability/{userId}")]
            public async Task<IActionResult> SetUserAvailability([FromBody] UserDTO a)
            {
                var result = await _accountManagementService.SetUserAvailability();
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }
        }
    }
}