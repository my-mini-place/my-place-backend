﻿using Domain;
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
        Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month,string userid);
        Task<Result<string>> AddUserEvent(CalendarEventDto eventDto);
        Task<Result<string>> AcceptOrRejectEvent(string eventId,string actionDto);
        Result<string> GetUsers();

        Task<Result<CalendarMonthFreeTime>> GetAvailabilityByMonth(string month);
        
    }
}
