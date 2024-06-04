using static Domain.Models.CalendarModels;

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
            public string actionDto { get; set; } = null!;
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
            public string Month { get; set; } = null!;
            public List<CalendarDayEventsDto> Days { get; set; } = null!;
        }

        public class CalendarDayEventsDto
        {
            public string Day { get; set; } = null!;
            public int DayNumber { get; set; }
            public List<CalendarEventDto> Events { get; set; } = null!;
        }

        public class CalendarEventDto
        {
            public string EventId { get; set; } = null!;
            public string Type { get; set; } = null!;
            public string Description { get; set; } = null!;
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public List<string> Invited { get; set; } = null!;
            public string State { get; set; } = null!;
        }

        public class UserDto
        {
            public string name { get; set; } = null!;
            public string role { get; set; } = null!;
            public string email { get; set; } = null!;
        }

        public class AvailabilityResponseDto
        {
            public string Day { get; set; } = null!;
            public List<KonserwatorDto> Konserwatorzy { get; set; } = null!;
        }

        public class KonserwatorDto
        {
            public string Imie { get; set; } = null!;
            public string Nazwisko { get; set; } = null!;
            public List<string> DostepneGodziny { get; set; } = null!;
        }

        public static class CalednarMapper
        {
            private static List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };

            public static CalendarEventDto castEventToClient(Event e)
            {
                CalendarEventDto eventDto = new();
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

            public static CalendarMonthEventsDto castEventsToClient(List<Event> events, int m, string month)
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

                foreach (Event e in events)
                {
                    CalendarEventDto evenCasted = castEventToClient(e);
                    int index = evenCasted.From.Day - 1;
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