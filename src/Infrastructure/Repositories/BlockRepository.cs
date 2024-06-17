using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BlockRepository : PagedRepository<Block>, IBlockRepository
    {
        public BlockRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}