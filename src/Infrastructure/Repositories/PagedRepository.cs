using Domain;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class PagedRepository<T> : IPagedRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public PagedRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //_db.Categories == dbSet
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        // tracked zwiększa performence dla danych tylko do odczytu
        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<PagedList<T>> GetAll(int page, int pageSize, Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
            string? sortColumn = null, string? sortOrder = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if(sortColumn != null && sortOrder != null)
            {

                if (sortOrder == "desc")
                    query = query.OrderByDescending(x => x.GetType().GetProperty(sortColumn)!.GetValue(x));
                else
                    query = query.OrderBy(x => x.GetType().GetProperty(sortColumn)!.GetValue(x));
            }
          

            // var Items= await query.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

            var items = await PagedList<T>.CreateAsync(query, page, pageSize);

            return items;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void Update(T obj)
        {
            try
            {
                dbSet.Update(obj);
            }
            catch
            {
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}