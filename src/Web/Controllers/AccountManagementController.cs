namespace My_Place_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Api.Interfaces;

    using global::My_Place_Backend.DTO.AccountManagment;
    using Microsoft.AspNetCore.Authorization;
    using Api.DTO.AccountManagment;

    namespace My_Place_Backend.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        [Authorize(Roles = "Admin")]
        public class AdminController : ControllerBase
        {
            private readonly IAccountManagementService _accountManagementService;

            public AdminController(IAccountManagementService accountManagementService)
            {
                _accountManagementService = accountManagementService;
            }

            [HttpPatch("changeAccountStatus/{id}")]
            public async Task<IActionResult> ChangeAccountStatus(string id, [FromBody] AccountStatusUpdateDTO statusUpdateDTO)
            {
                var result = await _accountManagementService.ChangeAccountStatus(id, statusUpdateDTO);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpPatch("updateAccount/{id}")]
            public async Task<IActionResult> UpdateAccount(string id, [FromBody] AdminUpdateAccountDTO updateAccountDTO)
            {
                var result = await _accountManagementService.UpdateAccount(id, updateAccountDTO);
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
        }
    }
}