using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.CalendarModels;

namespace Domain.IRepositories
{
    public interface ICalendarRepository : IRepository<Event>
    {
    }
}