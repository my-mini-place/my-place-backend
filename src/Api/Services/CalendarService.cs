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

        public async Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month,string userid)
        {
            if (months.Contains(month.ToLower()))
            {
                int index = months.IndexOf(month.ToLower()) + 1;
                //var events = _CalendarRepository.CalendarEvents.Where(e => e.Month == month).ToList();
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
            foreach (var user in _userManager.Users)
            {
                Console.WriteLine("----");
               // Console.WriteLine(user);
                Console.WriteLine(user.UserName);
               // sb.Append(user.Id + ",");
            }
            StringBuilder sb = new StringBuilder();
            List<usersDTO> output = new List<usersDTO>();
            List<ApplicationUser> users = _userManager.Users.Where(u => u.Email.ToLower().StartsWith(name.ToLower())).ToList();
            if (role != "")
            {
                foreach (ApplicationUser user in users)
                {
                    var roleResult = await _identityRepository.GetUserRolesAsync(user);
                   // Console.WriteLine("==========Role===========");
                   // Console.WriteLine(roleResult);

                    foreach (string s in roleResult)
                    {
                       // C/onsole.WriteLine("==========Rola===========");
                        //Console.WriteLine(s);
                    }
                    if (roleResult.Contains(role))
                    {
                        usersDTO us = new usersDTO();
                        us.email = user.Email;
                        us.id = user.Id;
                        //us.roles = roleResult.ToString();
                        output.Add(us);
                        //sb.Append(user.Id + ",");

                    }
                }

                //  users = users.Where(u => u.)
            }
            else
            {


                foreach (var user in users)
                {
                    //Console.WriteLine("----");
                    //Console.WriteLine(user);
                   // sb.Append(user.Id + ",");
                    usersDTO us = new usersDTO();
                    us.email = user.Email;
                    us.id = user.Id;
                    //us.roles = roleResult.ToString();
                    output.Add(us);
                }
            }
            return Result.Success(output);
        }
        public async Task<Result<string>> AddUserEvent(CalendarEventDto eventDto,string ownerId)
        {
            string id = Guid.NewGuid().ToString();
            eventDto.EventId = id;
            Console.WriteLine("DODAJE NOWE WYDARZENIE");
            Console.WriteLine(eventDto.Type);
            await _calendarRepository.Add(CalednarMapper.castEventDtoToServer(eventDto,ownerId));
            await _calendarRepository.Save();

            return Result.Success(id);
            // throw new NotImplementedException();
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