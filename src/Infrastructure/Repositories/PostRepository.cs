using Api.Interfaces.IRepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ApplicationDbContext _context;

        public PostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _context.Posts.FindAsync(postId);
        }

        public async Task<Guid> AddPostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
           
            return post.Id;  
        }

        public async Task UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
           
        }

        public async Task DeletePostAsync(Post post)
        {
            _context.Posts.Remove(post);
          
        }

        public async Task<List<Option>> GetOptionsByPostIdAsync(Guid postId)
        {
            return await _context.Options
                .Where(option => option.PostId == postId)
                .ToListAsync();
        }

        public async Task<int> CountVotesByOptionIdAsync(Guid optionId)
        {
            return await _context.Votes
                .Where(vote => vote.OptionId == optionId)
                .CountAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
