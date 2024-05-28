using System.Linq.Expressions;

namespace Domain.IRepositories
{
    public interface IPagedRepository<T> where T : class
    {
        Task<PagedList<T>> GetAll(int page, int pageSize, Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
          string? sortColumn = null, string? sortOrder = null);

        Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        Task Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        void Update(T entity);

        Task Save();
    }
}