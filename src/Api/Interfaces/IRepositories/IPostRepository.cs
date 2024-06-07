using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces.IRepositories
{
    public interface IPostsRepository
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<Guid> AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Post post);
        Task<List<Option>> GetOptionsByPostIdAsync(Guid postId);
        Task<int> CountVotesByOptionIdAsync(Guid optionId);

        Task SaveAsync();

    }
}
