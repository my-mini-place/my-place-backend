using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Interfaces;
using Domain;
using Domain.Models;
using Domain.ValueObjects;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


using Api.DTO.Posts;
using Api.Interfaces.IRepositories;
using Domain.Errors;

public class PostsService : IPostsService
{

    private readonly IPostsRepository _postsRepository;
    private readonly IVoteRepository _voteRepository;
    private readonly IOptionRepository _optionRepository;
    

    public PostsService(IPostsRepository postsRepository,IVoteRepository voteRepository,IOptionRepository optionRepository)
    {
        _postsRepository = postsRepository;
        _voteRepository = voteRepository;
        _optionRepository = optionRepository;
    }



    public async Task<PagedList<PostDTO>> GetPostsAsync(int page, int pageSize, string userRole, string userId)
    {
        var posts = await _postsRepository.GetAllPostsAsync();
        var postsDTO = new List<PostDTO>(); 

        foreach (var post in posts)
        {
            List<OptionDTO> options = new List<OptionDTO>();
            bool surveyClosed = post.IsSurvey && DateTime.UtcNow > post.SurveyClosureDateTime;
            if (post.IsSurvey)
            {
                var optionsFirst = await _optionRepository.GetAll(option => option.PostId == post.Id);
                foreach (var option in optionsFirst)
                {
                    var numVotes = await _voteRepository.CountVotes(option.Id.ToString());
                    options.Add(new OptionDTO
                    {
                        Id = option.Id,
                        Text = option.Text,
                        NumVotes = numVotes
                    });
                }
            }

            Vote? userVote = null;
            string userVoteMessage = "can't vote";
            if (userRole == Roles.Resident)
            {
                userVote = await _voteRepository.Get(vote => vote.PostId == post.Id && vote.UserId.ToString() == userId);
                userVoteMessage = userVote?.OptionId.ToString() ?? "don't vote";
            }

            postsDTO.Add(new PostDTO
            {
                Id = post.Id.ToString(),
                Title = post.Title,
                Content = post.Content,
                CreationDateTime = post.CreationDateTime,
                IsSurvey = post.IsSurvey,
                SurveyClosureDateTime = post.SurveyClosureDateTime,
                SurveyClosed = surveyClosed,
                OptionsWithNumVotes = options,
                UserVote = userVoteMessage
            });
        }

       
        var sortedPosts = postsDTO.OrderByDescending(post => post.CreationDateTime).ToList();

        return  PagedList<PostDTO>.CreateFromListAsync(sortedPosts, page, pageSize);
    }


    public async Task<Result<Guid>> CreatePostAsync(PostCreateDTO postDTO)
    {
        Guid postId = Guid.NewGuid();
        var post = new Post
        {
            Id = postId,
            Title = postDTO.Title,
            Content = postDTO.Content,
            CreationDateTime = DateTime.UtcNow,
            IsSurvey = postDTO.IsSurvey,
            SurveyClosureDateTime = postDTO.SurveyClosureDateTime,
            Options = postDTO.IsSurvey ? postDTO.OptionsWithNumVotes.Select(optionDTO => new Option
            {
                Id = Guid.NewGuid(),
                Text = optionDTO.Text,
                PostId = postId,
            }).ToList() : null
        };

       Guid PostId=   await  _postsRepository.AddPostAsync(post);
        await _postsRepository.SaveAsync();

        return Result.Success(PostId);
    }

    public async Task<Result> UpdatePostAsync(PostUpdateDTO postDTO)
    {
        var post = await _postsRepository.GetPostByIdAsync(Guid.Parse(postDTO.Id));
        if (post == null)
        {
            return Result.Failure(Error.NotFound("posts", "post dont find"));
        }

        post.Title = postDTO.Title ?? post.Title;
        post.Content = postDTO.Content ?? post.Content;
        await  _postsRepository.UpdatePostAsync(post);
        await _postsRepository.SaveAsync();

        return Result.Success();
    }

    public async Task<Result> VoteAsync(VoteDTO voteDTO)
    {
        var post = await _postsRepository.GetPostByIdAsync(voteDTO.PostId);
        if (post == null || DateTime.UtcNow >= post.SurveyClosureDateTime)
        {
            return Result.Failure(Error.NotFound("Invalid post ID or voting closed", "cs"));
        }

        var prevVote = await _voteRepository.Get(v => v.PostId == voteDTO.PostId && v.UserId == voteDTO.UserId);
        if (prevVote != null)
        {
           

            _voteRepository.Remove(prevVote);
        }



       await  _voteRepository.Add(new Vote
        {
            UserId = voteDTO.UserId,
            OptionId = voteDTO.OptionId,
            PostId = voteDTO.PostId
        });


        await _voteRepository.Save();
        return Result.Success();
    }

    public async Task<Result> DeletePostAsync(Guid postId)
    {
        var post = await _postsRepository.GetPostByIdAsync(postId);
        if (post == null)
        {
            return Result.Failure(Error.NotFound("PostId", "Post dont find!!"));
        }

        await _postsRepository.DeletePostAsync(post);
        await _postsRepository.SaveAsync();
        return Result.Success();
    }


}

