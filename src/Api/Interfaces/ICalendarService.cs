using Domain;
using static Domain.Calendar;

namespace Api.Interfaces
{
    public interface ICalendarService
    {
        public List<string> getMonths();
        Task<Result<CalendarMonthEventsDto>> GetEventsByMonth(string month,string userid);
        Task<Result<string>> AddUserEvent(CalendarEventDto eventDto,string ownerId);
        Task<Result<string>> AcceptOrRejectEvent(string eventId,string actionDto,string ownerId);
        Task<Result<List<usersDTO>>> GetUsers(string name,string role);

        Task<Result<CalendarMonthFreeTime>> GetAvailabilityByMonth(string month);
        
    }
}