using Api.Repositories;
using Domain.Models;
using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces.IRepositories
{
    public interface IVoteRepository : IRepository<Vote>
    {

        //_context.Votes.Count(vote => vote.OptionId == option.Id)

      public  Task<int > CountVotes(string optionId);

    }
}
