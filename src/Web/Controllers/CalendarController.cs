using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
//using Domain.Calendar;
using static Domain.Calendar;
using static Domain.Models.Calendar.CalendarModels;

namespace My_Place_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepository<Event> _calendarRepository;

        public CalendarController(ApplicationDbContext dbContext, IRepository<Event> calendarRepository)
        {
            _calendarRepository = calendarRepository;
            _dbContext = dbContext;
        }
        List<string> months = new List<string> {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
             };
        [HttpPost("user/calendar/event")]
        public IActionResult AddUserEvent([FromBody] CalendarEventDto eventDto)
        {
            string id  = Guid.NewGuid().ToString();
            eventDto.EventId = id;
            _calendarRepository.Add(CalednarMapper.castEventDtoToServer(eventDto));
            var events = _dbContext.CalendarEvents;
            foreach(Event e in events)
            {
                Console.WriteLine(e.Name);
                Console.WriteLine(e.Month);
            }
            return Ok();
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
                int index = months.IndexOf(month) + 1;
                var events = _dbContext.CalendarEvents.Where(e => e.Month == month).ToList();
                CalendarMonthEventsDto monthEvents =  CalednarMapper.castEventsToClient(events, index,month);
                return Ok(monthEvents);
            }
            else
            {
                return BadRequest("There is no such month");
            }

        }

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
