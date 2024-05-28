using Api.Repositories;
using Domain.Models.Identity;

namespace Api.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}