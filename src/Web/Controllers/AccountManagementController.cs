﻿using Domain.Models.Identity;
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
            public IActionResult ListUsers(string searchTerm, string sortColumn, string sortOrder, int page, int pageSize)
            {
                var users = _accountManagementService.ListUsers(searchTerm, sortColumn, sortOrder, page, pageSize);
                return Ok(users);
            }

            [HttpDelete("deleteUser/{userId}")]
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
            public async Task<IActionResult> GetUserInfo(string userId)
            {
                var result = await _accountManagementService.GetUserInfo(userId);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpPatch("updateUserRole/{userId}")]
            public async Task<IActionResult> UpdateUserRole([FromBody] string a)
            {
                var result = await _accountManagementService.UpdateUserRole();
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