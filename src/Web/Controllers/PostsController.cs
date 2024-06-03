using Api.DTO.Posts;
using Domain;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace My_Place_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<PostDTO>>> GetPosts(int page, int pagesize)
        {
            var posts = await _context.Posts.ToListAsync();


            var postsDTO = posts.Select(post =>
            {
                List<OptionDTO> options = null;
                bool surveyClosed = false;
                if (post.IsSurvey)
                {
                    if (DateTime.UtcNow > post.SurveyClosureDateTime)
                        surveyClosed = true;

                    options = _context.Options
                        .Where(option => option.PostId == post.Id)
                        .Select(option => new OptionDTO
                        {
                           Id = option.Id,
                            Text = option.Text,
                            NumVotes = surveyClosed ? _context.Votes.Count(vote => vote.OptionId == option.Id) : null
                        })
                        .ToList();
                }
                return new PostDTO
                {
                    Id = post.Id.ToString(),
                    Title = post.Title,
                    Content = post.Content,
                    CreationDateTime = post.CreationDateTime,
                    IsSurvey = post.IsSurvey,
                    SurveyClosureDateTime = post.SurveyClosureDateTime,
                    SurveyClosed = surveyClosed,
                    OptionsWithNumVotes = options
                };
            });
            


            PagedList<PostDTO> pagedPost =  PagedList<PostDTO>.CreateFromListAsync(postsDTO.OrderByDescending(p => p.CreationDateTime).ToList(), page, pagesize);;
             

          


            return pagedPost;
        }

      

        [HttpPost("create")]
        public async Task<IActionResult> CeateSurveyPost([FromBody] PostCreateDTO postDTO)
        {

            Guid postId = Guid.NewGuid();
            var post = new Post
            {
                
                Title = postDTO.Title,
                Content = postDTO.Content,
                CreationDateTime = DateTime.UtcNow,
                IsSurvey =  postDTO.IsSurvey,
                SurveyClosureDateTime = postDTO.SurveyClosureDateTime, // check for null
                Options = postDTO.IsSurvey ? postDTO.OptionsWithNumVotes!.Select(optionDTO => new Option  // check for null
                {
                    Id=Guid.NewGuid(),
                   
                    Text = optionDTO.Text,
                    PostId =postId,
                })
                    .ToList() : null
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Ok();
        }



        [HttpPatch("Update")]
        public async Task<IActionResult> UpdatePost([FromBody] PostUpdateDTO postDTO)
        {       

            var post = await _context.Posts.FindAsync(Guid.Parse(postDTO.Id));

            if (post == null)
                return BadRequest();


            post.Title = postDTO.Title ?? post.Title;
            post.Content = postDTO.Content ?? post.Content;

           _context.Posts.Update(post);
            _context.SaveChanges();



            return Ok();
        }

        // [HttpPost("{optionId}")] public async Task<IActionResult> CeateOrUpdateVote(Guid
        // optionId) { var option = await _context.Options.FindAsync(optionId); if(option == null)
        // return NotFound();

        // var post = await _context.Posts.FindAsync(option.PostId); if(post == null) return NotFound();

        // if(post.SurveyClosureDateTime < DateTime.UtcNow) { var vote = new Vote { OptionId =
        // optionId }; _context.Votes.Add(vote); await _context.SaveChangesAsync(); } return Ok(); }


        [HttpPost]
        [Route("vote")]
        public async Task<IActionResult> CeateOrUpdateVote(Vote vote)
        {
            var post = await _context.Posts.FindAsync(vote.PostId);
            if (post == null) return NotFound();

            if (DateTime.UtcNow < post.SurveyClosureDateTime)
            {
                var prevVote = await _context.Votes.FirstOrDefaultAsync(v => v.PostId == vote.PostId && v.UserId == vote.UserId);

                if (prevVote != null)
                {
                    _context.Votes.Remove(prevVote);

                    if (prevVote.OptionId != vote.OptionId)
                        _context.Votes.Add(vote);
                }
                else
                {
                    _context.Votes.Add(vote);
                }

                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
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