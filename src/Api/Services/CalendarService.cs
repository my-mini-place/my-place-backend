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
using Api.IRepositories;
using Domain.Models.Identity;
using static System.Net.Mime.MediaTypeNames;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using static Domain.Models.Calendar.CalendarModels;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.Xml;

namespace Api.Services
{
    public static class FreeTimeManager
    {
        public static List<Slot> GetFreeTimeSlots(List<Event> events, DateTime day)
        {
            var eventsOnDay = events.Where(e => e.StartTime.Date == day.Date).ToList();

            DateTime startOfDay = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            DateTime endOfDay = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);

            eventsOnDay = eventsOnDay.OrderBy(e => e.StartTime).ToList();

            List<Slot> freeTimeSlots = new List<Slot>();

            DateTime currentStart = startOfDay;

            foreach (var ev in eventsOnDay)
            {

                    Console.WriteLine("dodaje");
                    Console.WriteLine(ev.StartTime);
                    Console.WriteLine(ev.EndTime);
                Console.WriteLine(ev.Name);

                if (ev.StartTime > currentStart)
                {
                    Slot S = new Slot();
                    S.Start = currentStart;
                    S.End = ev.StartTime;
                    freeTimeSlots.Add(S);

                    Console.WriteLine("dodaje");
                    Console.WriteLine(currentStart);
                    Console.WriteLine(ev.StartTime);
                }
                currentStart = ev.EndTime > currentStart ? ev.EndTime : currentStart;
            }

            if (currentStart < endOfDay)
            {

                Console.WriteLine("dodaje");
                Console.WriteLine(currentStart);
                Console.WriteLine(endOfDay);
                Slot S = new Slot();
                S.Start = currentStart;
                S.End = endOfDay;
                freeTimeSlots.Add(S);
                //freeTimeSlots.Add((currentStart.ToString(), endOfDay.ToString()));
            }

            return freeTimeSlots;
        }
    }

    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly UserManager<ApplicationUser> _userManager ;

        private readonly List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };

        private enum  actions { Accept, TReject };

    public CalendarService(ICalendarRepository calendarRepository, UserManager<ApplicationUser> userManager )
        {
            _calendarRepository = calendarRepository;
            _userManager = userManager;
        }

        public async Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month,string userid)
        {
            if (months.Contains(month))
            {
                int index = months.IndexOf(month) + 1;
                //var events = _CalendarRepository.CalendarEvents.Where(e => e.Month == month).ToList();
                var events =  await _calendarRepository.GetAll(x => (x.Month == month)&&x.Invited.Contains(userid));

                CalendarMonthEventsDto monthEvents = CalednarMapper.castEventsToClient(events, index, month);
                return Result.Success(monthEvents);
            }
            else
            {
                return Result.Failure<CalendarMonthEventsDto>(Error.Failure("NoMonth","there is no such month"));

            }
        }

        public Result<string> GetUsers()
        {

            var users  = _userManager.Users;
            StringBuilder sb = new StringBuilder();
            foreach (var user in users)
            {
                Console.WriteLine("----");
                Console.WriteLine(user);
                sb.Append(user.Id + ",");
            }
            return Result.Success(sb.ToString());
        }
        public async Task<Result<string>> AddUserEvent(CalendarEventDto eventDto)
        {
            string id = Guid.NewGuid().ToString();
            eventDto.EventId = id;
            await _calendarRepository.Add(CalednarMapper.castEventDtoToServer(eventDto));
            return Result.Success(id);
           // throw new NotImplementedException();
        }

        public async Task<Result<string>> AcceptOrRejectEvent(string eventId, string actionDto)
        {
            var e = await _calendarRepository.Get(x => x.EventPublicId == eventId);

        try
        {
                actions userAction = (actions)Enum.Parse(typeof(actions), actionDto);
                if (userAction == actions.Accept)
                {
                    e.State = "Accepted";
                    _calendarRepository.Update(e);
                    return Result.Success("Event Accepted!!");
                }
                else
                {
                    e.State = "Rejected";
                    _calendarRepository.Update(e);
                    return Result.Success("Event Rejected!!");
                }
        }
        catch
        {
                return Result.Failure<String>(Error.Failure("NoSuchAction", "there is no such action"));
            }

        }

        public async Task<Result<CalendarMonthFreeTime>> GetAvailabilityByMonth(string month)
        {
            int year = DateTime.Now.Year; // Rok
            int index = months.IndexOf(month) + 1;
            
            int daysInMonth = DateTime.DaysInMonth(year, index); // Pobranie liczby dni w miesiącu
            var events = await _calendarRepository.GetAll(x => (x.Month == month));

            // Generowanie listy dni w miesiącu
            var daysOfMonth = Enumerable.Range(1, daysInMonth).Select(day => new DateTime(year, index, day)).ToList();
            CalendarMonthFreeTime monthObject = new CalendarMonthFreeTime();
            monthObject.Days = new List<CalendarDayFreeTime>();
            monthObject.Month = month;
            foreach (var day in daysOfMonth)
            {
                CalendarDayFreeTime dayObject = new CalendarDayFreeTime();
                dayObject.DayNumber = day.Day;
                dayObject.Day = day.DayOfWeek.ToString();
                dayObject.FreeTimeList = FreeTimeManager.GetFreeTimeSlots(events, day);

                monthObject.Days.Add(dayObject);
            }

            //foreach (Event e in events)
            //{
            //    CalendarEventDto evenCasted = castEventToClient(e);
            //    int index = evenCasted.From.Day - 1;
            //    monthObject.Days[index].Events.Add(evenCasted);
            //}
            return monthObject;
           // throw new NotImplementedException();
        }
    }
}
