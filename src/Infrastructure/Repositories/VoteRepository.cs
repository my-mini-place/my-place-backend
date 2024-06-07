using Api.Interfaces.IRepositories;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext db) : base(db)
        {

            
        }

        public async Task<int> CountVotes(string optionId)
        {
          int result=  await   dbSet.CountAsync(vote => vote.OptionId.ToString() == optionId);
            return result;
        }
    }
}
