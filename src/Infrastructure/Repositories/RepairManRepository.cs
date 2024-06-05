using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepairmanRepository : Repository<Repairman>, IRepairmanRepository
    {
        public RepairmanRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
