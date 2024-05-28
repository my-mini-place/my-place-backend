using Domain;
using static Domain.Calendar;

namespace Api.Interfaces
{
    public interface ICalendarService
    {
        Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month);

        Task<Result<string>> AddUserEvent(CalendarEventDto eventDto);

        Task<Result<string>> AcceptOrRejectEvent(string eventId, string actionDto);
    }
}