using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ResidenceRepository : Repository<Residence>, IResidenceRepository
    {
        public ResidenceRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}