using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        Task<T?> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        Task Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        void Update(T entity);

        Task Save();
    }
}