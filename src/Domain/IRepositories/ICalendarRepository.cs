﻿using Domain.Repositories;
using static Domain.Models.Calendar.CalendarModels;


namespace Domain.IRepositories
{
    public interface ICalendarRepository : IRepository<Event>
    {
     //   void GetAll(Func<Event, bool> func);
    }
}