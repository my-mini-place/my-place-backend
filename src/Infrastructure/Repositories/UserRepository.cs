using Domain.IRepositories;
using Domain.Models.Identity;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext db) : PagedRepository<User>(db), IUserRepository
{
}