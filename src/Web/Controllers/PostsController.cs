using Api.DTO.Posts;
using Api.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Place_Backend.Authorization;
using Serilog;
using System;
using System.Threading.Tasks;
using Web.Extensions;

namespace My_Place_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        [Authorize("IsAny")]
        public async Task<ActionResult<PagedList<PostDTO>>> GetPosts(int page, int pageSize)
        {
            string userRole = User.GetUserRole(); 
            string userId = User.GetUserId();
            var result = await _postsService.GetPostsAsync(page, pageSize, userRole, userId);
            
            return Ok(result);
        }

        [HttpPost("Create")]
        [Authorize("IsAdmin")]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateDTO postDTO)
        {
            var result = await _postsService.CreatePostAsync(postDTO);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpPatch("Update")]
        [Authorize("IsAdmin")]
        public async Task<IActionResult> UpdatePost([FromBody] PostUpdateDTO postDTO)
        {
            var result = await _postsService.UpdatePostAsync(postDTO);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.ToProblemDetails());
            }
        }

        [HttpPost("Vote")]
        [Authorize("IsResident")]
        public async Task<IActionResult> Vote([FromBody] VoteDTO voteDTO)
        {
            var result = await _postsService.VoteAsync(voteDTO);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete("{postId}")]
        [Authorize("IsAdmin")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var result = await _postsService.DeletePostAsync(postId);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound(result.Error);
            }
        }
    }
}
