using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
//using Domain.Calendar;
using static Domain.Calendar;

namespace My_Place_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        //  private readonly ICalendarService _calendarService;

        //public CalendarController(ICalendarService calendarService)
        //{
        //    _calendarService = calendarService;
        //}
        List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };
        [HttpPost("user/calendar/event")]
        public IActionResult AddUserEvent([FromBody] CalendarEventDto eventDto)
        {
            // Tutaj możesz wywołać odpowiednią metodę serwisu kalendarza, aby dodać wydarzenie
            // Użyj eventDto, aby uzyskać dane o nowym wydarzeniu
            // Zwróć odpowiedni wynik w zależności od rezultatu operacji
            return Ok(new { eventId = Guid.NewGuid().ToString() });
        }

        [HttpPost("admin/calendar/event")]
        public IActionResult AddAdminEvent([FromBody] CalendarEventDto eventDto)
        {



            // Analogicznie jak powyżej, tutaj dodajesz wydarzenie jako administrator
            return Ok(new { eventId = Guid.NewGuid().ToString() });
        }

        [HttpGet("users")]
        public IActionResult GetUsers([FromQuery] string name, [FromQuery] string role)
        {
            // Tutaj pobierasz listę użytkowników w zależności od podanych parametrów
            // Użyj serwisu lub repozytorium do pobrania danych użytkowników
            var users = new List<UserDto>(); // Zastąp tę linię kodem, który pobiera użytkowników
            return Ok(users);
        }

        [HttpPost("calendar/events/{eventId}")]
        public IActionResult AcceptOrRejectEvent(string eventId, [FromBody] string actionDto)
        {
            // Tutaj możesz wywołać odpowiednią metodę serwisu kalendarza, aby zaakceptować lub odrzucić wydarzenie
            // Użyj eventId do identyfikacji wydarzenia, a actionDto do uzyskania informacji o akcji (accept lub decline)
            // Zwróć odpowiedni wynik w zależności od rezultatu operacji
            return Ok(new { message = "Akcja została pomyślnie wykonana." });
        }

        [HttpGet("calendar/events")]
        public ActionResult<CalendarMonthEventsDto> GetEventsByMonth([FromQuery] string month)
        {

            if (months.Contains(month))
            {
                CalendarMonthEventsDto MonthEvents = new CalendarMonthEventsDto();
                MonthEvents.Month = month;
                MonthEvents.Days = new List<CalendarDayEventsDto>();
                CalendarDayEventsDto sampleDay = new CalendarDayEventsDto();
                sampleDay.Day = "1";
                CalendarEventDto sampleEvent = new CalendarEventDto();

                sampleEvent.EventId = "1";
                sampleEvent.Type = "custom";
                sampleEvent.Description = "description";
                sampleEvent.State = "created";
                sampleEvent.Invited = new List<string>();
                sampleEvent.From = new DateTime();
                sampleEvent.To = new DateTime();

                sampleDay.Events = new List<CalendarEventDto>();
                sampleDay.Events.Add(sampleEvent);
                MonthEvents.Days.Add(sampleDay);


                return Ok(MonthEvents);
            }
            else
            {
                return BadRequest("There is no such month");
            }

        }
        // Analogicznie obsłuż pozostałe endpointy zgodnie z ich specyfikacją


        [HttpGet("availability")]
        [ProducesResponseType(typeof(List<AvailabilityResponseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAvailabilityByMonth([FromQuery] string month)
        {
            // Przykładowe pobieranie dostępności konserwatorów dla danego miesiąca
            var availability = new List<AvailabilityResponseDto>(); // Zastąp tę linię kodem, który pobiera dostępność konserwatorów

            // Tworzenie przykładowych danych
            var response = new List<AvailabilityResponseDto>
            {
                new AvailabilityResponseDto
                {
                    Day = "2024-03-10",
                    Konserwatorzy = new List<KonserwatorDto>
                    {
                        new KonserwatorDto
                        {
                            Imie = "Jan",
                            Nazwisko = "Kowalski",
                            DostepneGodziny = new List<string> { "10:00", "11:00", "14:00" }
                        },
                        new KonserwatorDto
                        {
                            Imie = "Anna",
                            Nazwisko = "Nowak",
                            DostepneGodziny = new List<string> { "09:00", "12:00", "15:00" }
                        }
                    }
                }
            };

            return Ok(response);
        }
    }
}
