using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Calendar
    {
        public class CalendarMonthEventsDto
        {
            public string Month { get; set; }
            public List<CalendarDayEventsDto> Events { get; set; }
        }

        public class CalendarDayEventsDto
        {
            public string Day { get; set; }
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
    }
}
