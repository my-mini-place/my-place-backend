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

namespace Api.Services
{
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
    }
}
