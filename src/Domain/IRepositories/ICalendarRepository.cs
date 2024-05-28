using Domain.Repositories;
using static Domain.Models.CalendarModels;

namespace Domain.IRepositories
{
    public interface ICalendarRepository : IRepository<Event>
    {
    }
}