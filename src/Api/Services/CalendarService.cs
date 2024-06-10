using Api.Interfaces;
using Domain;
using Domain.Errors;
using Domain.IRepositories;
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
using Api.Interfaces.IRepositories;
using IIdentityRepository = Api.Interfaces.IIdentityRepository;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;
using System.Collections.Generic;

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


                if (ev.StartTime > currentStart)
                {
                    Slot S = new Slot();
                    S.Start = currentStart;
                    S.End = ev.StartTime;
                    freeTimeSlots.Add(S);
                }
                currentStart = ev.EndTime > currentStart ? ev.EndTime : currentStart;
            }

            if (currentStart < endOfDay)
            {
                Slot S = new Slot();
                S.Start = currentStart;
                S.End = endOfDay;
                freeTimeSlots.Add(S);
            }

            return freeTimeSlots;
        }
    }

    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly UserManager<ApplicationUser> _userManager ;
        private readonly IIdentityRepository _identityRepository;

        private readonly List<string> months = new List<string> {
            "january", "february", "march", "april", "may", "june",
            "july", "august", "september", "october", "november", "december"
             };
        public enum actions
        { Accept, TReject };

    public CalendarService(ICalendarRepository calendarRepository, UserManager<ApplicationUser> userManager, IIdentityRepository identityRepository)
        {
            _calendarRepository = calendarRepository;
            _userManager = userManager;
            _identityRepository = identityRepository;

        }

        public List<string> getMonths()
        {
            return months;
        }
        public async Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month,string userid)
        {
            if (months.Contains(month.ToLower()))
            {
                int index = months.IndexOf(month.ToLower()) + 1;
                var events =  await _calendarRepository.GetAll(x => (x.Month.ToLower() == month.ToLower()) &&(x.Invited.Contains(userid)||x.owner==userid));
                foreach(var e in events)
                {
                    Console.WriteLine(e);
                }    
                CalendarMonthEventsDto monthEvents = CalednarMapper.castEventsToClient(events, index, month.ToLower());
                return Result.Success(monthEvents);
            }
            else
            {
                return Result.Failure<CalendarMonthEventsDto>(Error.Failure("NoMonth", "there is no such month"));
            }
        }

        public async Task<Result<List<usersDTO>>> GetUsers(string name,string role)
        {

            StringBuilder sb = new StringBuilder();
            List<usersDTO> output = new List<usersDTO>();
            List<ApplicationUser> users = _userManager.Users.Where(u => u.Email.ToLower().StartsWith(name.ToLower())).ToList();
            if (role == Roles.Administrator || role == Roles.Resident || role == Roles.Manager || role == Roles.User || role == Roles.Repairman)
            {
                foreach (ApplicationUser user in users)
                {
                    var roleResult = await _identityRepository.GetUserRolesAsync(user);
                    if (roleResult.Contains(role))
                    {
                        usersDTO us = new usersDTO();
                        us.email = user.Email;
                        us.id = user.Id;
                        output.Add(us);


                    }
                }

            }
            else if(role=="")
            { 
                foreach (var user in users)
                {
                    usersDTO us = new usersDTO();
                    us.email = user.Email;
                    us.id = user.Id;
                    output.Add(us);
                }
            }
            else
            {
                return Result.Failure<List<usersDTO>> (Error.NotFound("NoSuchRole", "there is no such role"));

            }
            return Result.Success(output);
        }
        public async Task<Result<string>> AddUserEvent(CalendarEventDto eventDto,string ownerId)
        {
            string id = Guid.NewGuid().ToString();
            eventDto.EventId = id;

            await _calendarRepository.Add(CalednarMapper.castEventDtoToServer(eventDto,ownerId));
            await _calendarRepository.Save();
            return Result.Success(id);
        }

        public async Task<Result<string>> AcceptOrRejectEvent(string eventId, string actionDto,string ownerid)
        {
            var e = await _calendarRepository.Get(x => (x.EventPublicId == eventId&&x.Invited.Contains(ownerid)));
            if(e==null)
                return Result.Failure<String>(Error.Failure("ThereIsNoEvent", "there is no such event"));

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
            int year = DateTime.Now.Year;
            int index = months.IndexOf(month) + 1;
            
            int daysInMonth = DateTime.DaysInMonth(year, index);
            var events = await _calendarRepository.GetAll(x => (x.Month == month));

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

            return monthObject;
        }
    }
}