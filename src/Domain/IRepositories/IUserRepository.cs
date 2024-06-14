using Domain.Models.Identity;
using System.Linq.Expressions;

namespace Domain.IRepositories
{
    public interface IUserRepository : IPagedRepository<User>
    {
        Task<PagedList<User>> GetAllUser(int page, int pageSize, Expression<Func<User, bool>>? filter = null, string? includeProperties = null,
       string? sortColumn = null, string? sortOrder = null);
    }
}