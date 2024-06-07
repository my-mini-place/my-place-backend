using Api.DTO.Posts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IPostsService
    {
        Task<PagedList<PostDTO>> GetPostsAsync(int page, int pageSize,string UserRole, string UserId);
        Task<Result<Guid>> CreatePostAsync(PostCreateDTO postDTO);
        Task<Result> UpdatePostAsync(PostUpdateDTO postDTO);
        Task<Result> VoteAsync(VoteDTO voteDTO);
        Task<Result> DeletePostAsync(Guid postId);
    }
}
