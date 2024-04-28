using Api.Repositories;
using Domain.Models.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}