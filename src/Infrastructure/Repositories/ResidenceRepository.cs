using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ResidenceRepository : PagedRepository<Residence>, IResidenceRepository
    {
        public ResidenceRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}