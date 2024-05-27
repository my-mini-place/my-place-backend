using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Calendar.CalendarModels;

namespace Domain
{
    public class Calendar
    {
        public enum UserEventType
        {
            Usterka,
            SpotkanieAdmin
        }

        public enum AdminEventType
        {
            Custom,
            SpotkanieOrganizacyjne
        }

        public class usersDTO
        {
           public string email { get; set; }
           public string id{ get; set; }
         //  public string roles { get; set; }
        }
        public class ActionDto
        {
            public string actionDto { get; set; }
        }
        public class CalendarMonthFreeTime
        {
            public string Month { get; set; }
            public List<CalendarDayFreeTime> Days { get; set; }
        }
        public class CalendarDayFreeTime
        {
            public string Day { get; set; }
            public int DayNumber { get; set; }
            public List<Slot> FreeTimeList { get; set; }
        }
        public class Slot
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
        public class CalendarMonthEventsDto
        {
            public string Month { get; set; }
            public List<CalendarDayEventsDto> Days { get; set; }
        }

        public class CalendarDayEventsDto
        {
            public string Day { get; set; }
            public int DayNumber { get; set; }
            public List<CalendarEventDto> Events { get; set; }
        }

        public class CalendarEventDto
        {
            public string EventId { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public List<string> Invited { get; set; }
            public string State { get; set; }
        }

        public class UserDto
        {
            public string name { get; set; }
            public string role { get; set; }
            public string email { get; set; }
        }


        public class AvailabilityResponseDto
        {
            public string Day { get; set; }
            public List<KonserwatorDto> Konserwatorzy { get; set; }
        }

        public class KonserwatorDto
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public List<string> DostepneGodziny { get; set; }
        }

        public static class CalednarMapper
        {
            private static List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };
            public static CalendarEventDto castEventToClient(Event e)
            {
                CalendarEventDto eventDto = new CalendarEventDto();
                eventDto.EventId = e.EventPublicId;
                eventDto.Type = e.Type;
                eventDto.State = e.State;
                eventDto.Description = e.Description;
                eventDto.From = e.StartTime;
                eventDto.To = e.EndTime;
                eventDto.Invited = new List<string>();
                
                foreach (var item in e.Invited.Split([',']))
                {
                    eventDto.Invited.Add(item);
                }
                return eventDto;
            }
            public static CalendarMonthEventsDto castEventsToClient(List<Event> events,int m,string month)
            {
                int year = DateTime.Now.Year; // Rok

                int daysInMonth = DateTime.DaysInMonth(year, m); // Pobranie liczby dni w miesiącu

                // Generowanie listy dni w miesiącu
                var daysOfMonth = Enumerable.Range(1, daysInMonth).Select(day => new DateTime(year, m, day)).ToList();
                CalendarMonthEventsDto monthObject = new CalendarMonthEventsDto();
                monthObject.Days = new List<CalendarDayEventsDto>();
                monthObject.Month = month;
                foreach (var day in daysOfMonth)
                {
                    CalendarDayEventsDto dayObject = new CalendarDayEventsDto();
                    dayObject.DayNumber = day.Day;
                    dayObject.Day = day.DayOfWeek.ToString();
                    dayObject.Events = new List<CalendarEventDto>();
                    monthObject.Days.Add(dayObject);
                }

                foreach(Event e in events)
                {
                    CalendarEventDto evenCasted = castEventToClient(e);
                    int index = evenCasted.From.Day-1;
                    monthObject.Days[index].Events.Add(evenCasted);
                }
                return monthObject;
            }

            public static Event castEventDtoToServer(CalendarEventDto e ,string ownderId)
            {
                Event serverEvent = new Event();
                serverEvent.EventPublicId = e.EventId;
                serverEvent.Description = e.Description;
                serverEvent.Type = e.Type;
                serverEvent.Name = "nazwa testowa";
                serverEvent.StartTime = e.From;
                serverEvent.EndTime = e.To;
                serverEvent.State = "Created";
                serverEvent.Month = months[e.From.Month-1];
                serverEvent.owner = ownderId;
                serverEvent.Invited = "";
                StringBuilder sb = new StringBuilder();
                foreach (string id in e.Invited)
                {

                    sb.Append(id + ",");
                }
                serverEvent.Invited = sb.ToString();
                return serverEvent;
            }

            
        }
    }
}
