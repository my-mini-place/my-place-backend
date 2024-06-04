using Domain.IRepositories;
using Infrastructure.Data;
using static Domain.Models.Calendar.CalendarModels;


namespace Infrastructure.Repositories
{
    public class CalendarRepository : Repository<Event>, ICalendarRepository
    {
        public CalendarRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}