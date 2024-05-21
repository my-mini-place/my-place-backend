using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Api.DTO.Posts;
using Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace My_Place_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDTO>>> GetPosts()
        {

            var posts = await _context.Posts.ToListAsync();
            var postsDTO = await Task.WhenAll(posts.Select(async post =>
            {
                List<OptionDTO> options = null;
                bool surveyClosed = false;
                if(post.IsSurvey)
                {
                    if(DateTime.UtcNow > post.SurveyClosureDateTime)
                        surveyClosed = true;

                    options = await _context.Options
                        .Where(option => option.PostId == post.Id)
                        .Select(option => new OptionDTO 
                        {
                            Id = option.Id,
                            Text = option.Text,
                            NumVotes = surveyClosed ? _context.Votes.Count(vote => vote.OptionId == option.Id) : null
                        })
                        .ToListAsync();
                }
                return new PostDTO 
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    CreationDateTime = post.CreationDateTime,
                    IsSurvey = post.IsSurvey,
                    SurveyClosureDateTime = post.SurveyClosureDateTime,
                    SurveyClosed = surveyClosed,
                    OptionsWithNumVotes = options
                };
            }));

            return postsDTO
                    .OrderByDescending(post => post.CreationDateTime)
                    .ToList();
        }

        [HttpPost("newtext")]
        public async Task<IActionResult> CeateTextPost(PostDTO postDTO)
        {
            var post = new Post {
                Title = postDTO.Title,
                Content = postDTO.Content,
                CreationDateTime = DateTime.UtcNow,
                IsSurvey = false
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("newsurvey")]
        public async Task<IActionResult> CeateSurveyPost(PostDTO postDTO)
        {
            var post = new Post {
                Title = postDTO.Title,
                Content = postDTO.Content,
                CreationDateTime = DateTime.UtcNow,
                IsSurvey = true,
                SurveyClosureDateTime = postDTO.SurveyClosureDateTime, // check for null
                Options = postDTO.OptionsWithNumVotes.Select(optionDTO => new Option  // check for null
                {
                    Text = optionDTO.Text,
                    PostId = postDTO.Id,
                })
                    .ToList()
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // [HttpPost("{optionId}")]
        // public async Task<IActionResult> CeateOrUpdateVote(Guid optionId)
        // {
        //     var option = await _context.Options.FindAsync(optionId);
        //     if(option == null)
        //         return NotFound();

        //     var post = await _context.Posts.FindAsync(option.PostId);
        //     if(post == null)
        //         return NotFound();

        //     if(post.SurveyClosureDateTime < DateTime.UtcNow)
        //     {
        //         var vote = new Vote 
        //         {
        //             OptionId = optionId
        //         };
        //         _context.Votes.Add(vote);
        //         await _context.SaveChangesAsync();
        //     }
        //     return Ok();
        // }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if(post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}