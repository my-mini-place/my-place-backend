﻿using Api.Interfaces;
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
        private readonly ICalendarRepository _calendarRepository;

        private readonly List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };

        private enum Actions
        { Accept, TReject };

        public CalendarService(ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        public async Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month)
        {
            if (months.Contains(month))
            {
                int index = months.IndexOf(month) + 1;
                //var events = _CalendarRepository.CalendarEvents.Where(e => e.Month == month).ToList();
                var events = await _calendarRepository.GetAll(x => x.Month == month);

                CalendarMonthEventsDto monthEvents = CalednarMapper.castEventsToClient(events, index, month);
                return Result.Success(monthEvents);
            }
            else
            {
                return Result.Failure<CalendarMonthEventsDto>(Error.Failure("NoMonth", "there is no such month"));
            }
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
                Actions userAction = (Actions)Enum.Parse(typeof(Actions), actionDto);
                if (userAction == Actions.Accept)
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
                return Result.Failure<string>(Error.Failure("NoSuchAction", "there is no such action"));
            }
        }
    }
}