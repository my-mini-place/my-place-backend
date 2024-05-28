using Domain.Models.Identity;

namespace Domain.IRepositories
{
    public interface IUserRepository : IPagedRepository<User>
    {
    }
}