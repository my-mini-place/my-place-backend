namespace My_Place_Backend.Controllers
{
    using Api.DTO.AccountManagment;
    using Api.Interfaces;
    using Domain;
    using global::My_Place_Backend.Authorization;
    using global::My_Place_Backend.DTO.AccountManagment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

            [HttpPatch("updateAccount")]
            public async Task<IActionResult> UpdateAccount( [FromBody] UserUpdateDTO updateAccountDTO)
            {
                //string UserRole = "Administrator";
                //if (User.GetUserRole()!= null)
                //{
                //UserRole=User.GetUserRole();
                //}

                var result = await _accountManagementService.UpdateAccount(updateAccountDTO.Id, updateAccountDTO,"Administrator");
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok();
            }

            [HttpGet("users")]
            public async Task<IActionResult> ListUsers(int page, int pageSize,string? searchTerm, string? sortColumn, string? sortOrder)
            {
                var users = await _accountManagementService.ListUsers(page, pageSize, searchTerm, sortColumn, sortOrder);
                if (users.IsFailure)
                {
                    return BadRequest(users.Error);
                }

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
            public async Task<IActionResult> GetUserInfo(string userId)
            {

                string userRole = User.GetUserRole();
                string senderId = User.GetUserId().ToString();

                if ((userRole!= "Administrator"&&userRole!= "Manager")&&senderId!=userId)
                {
                    return BadRequest(Result.Failure(Domain.Errors.Error.Conflict("Dont have permission", "No permission")));
                }
                //     userId = User.GetUserId().ToString();
                    //string userRole = User.GetUserRole();
                

                var result = await _accountManagementService.GetUserInfo(userId);
                if (result.IsFailure)
                {
                    return BadRequest(result.Error);
                }
                return Ok(result.Value);
            }

          

            //[HttpPatch("setUserAvailability/{userId}")]
            //public async Task<IActionResult> SetUserAvailability([FromBody] UserDTO a)
            //{
            //    var result = await _accountManagementService.SetUserAvailability();
            //    if (result.IsFailure)
            //    {
            //        return BadRequest(result.Error);
            //    }
            //    return Ok();
            //}
        }
    }
}