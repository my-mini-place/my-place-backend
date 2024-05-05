using Domain;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Calendar;

namespace Api.Interfaces
{
    public interface ICalendarService
    {
        Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month);
    }
}
