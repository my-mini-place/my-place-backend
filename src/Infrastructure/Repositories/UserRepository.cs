using Domain.IRepositories;
using Domain.Models.Identity;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext db) : PagedRepository<User>(db), IUserRepository
{
}