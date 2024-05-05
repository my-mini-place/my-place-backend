using Api.Interfaces;
using AutoMapper;
using Domain;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using Domain.Repositories;
using My_Place_Backend.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Calendar;
using Domain.Errors;

namespace Api.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _CalendarRepository;
        private readonly List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };
        public CalendarService(ICalendarRepository calendarRepository)
        {
            _CalendarRepository = calendarRepository;

        }

        public async Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month)
        {
            if (months.Contains(month))
            {
                int index = months.IndexOf(month) + 1;
                //var events = _CalendarRepository.CalendarEvents.Where(e => e.Month == month).ToList();
                var events =  await _CalendarRepository.GetAll(x => x.Month == month);

                CalendarMonthEventsDto monthEvents = CalednarMapper.castEventsToClient(events, index, month);
                return Result.Success(monthEvents);
            }
            else
            {
                return Result.Failure<CalendarMonthEventsDto>(Error.Failure("No month","there is no such month"));

            }
        }
    }
}
