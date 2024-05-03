using Domain.IRepositories;
using Domain.Models.Identity;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Calendar.CalendarModels;
using Domain.Repositories;


namespace Infrastructure.Repositories
{
    public class CalendarRepository : Repository<Event>, IRepository<Event>
    {
        public CalendarRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
