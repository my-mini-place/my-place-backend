using Domain;
using Domain.IRepositories;
using Domain.Models.Identity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using System.Net.Http.Headers;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext db) : PagedRepository<User>(db), IUserRepository
{



    public async Task<PagedList<User>> GetAllUser(int page, int pageSize, Expression<Func<User, bool>>? filter = null, string? includeProperties = null,
        string? sortColumn = null, string? sortOrder = null)
    {
        IQueryable<User> query = dbSet;
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

        Expression<Func<User,object>> keySelector = sortColumn switch
        {
            "Id" => x => x.Id,
            "Surname" => x => x.Surname,
            "UserName" => x => x.Name,
            "Email" => x => x.Email,
            "Date " => x => x.CreatedAt,
            "Role" => x => x.Role,
            
          
            _ => x => x.Id
        };



        if (sortColumn != null && sortOrder != null)
        {

            if (sortOrder == "desc")
                query = query.OrderByDescending(keySelector);
            else
                query = query.OrderBy(keySelector);
        }


        // var Items= await query.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

        var items = await PagedList<User>.CreateAsync(query, page, pageSize);

        return items;
    }

}