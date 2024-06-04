using Api.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

//using Domain.Calendar;
using static Domain.Calendar;
using static Domain.Models.Calendar.CalendarModels;
using Web.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using My_Place_Backend.Authorization;
using Microsoft.AspNetCore.Authorization;
using Domain.IRepositories;
using System.Security.Cryptography.Xml;
using Domain.Errors;


namespace My_Place_Backend.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;


        public CalendarController( ICalendarService calendarService)
        {
            _calendarService = calendarService;

        }
        [Authorize("IsResident")]
        [HttpPost("user/calendar/event")]
        public async Task<object> AddUserEvent([FromBody] CalendarEventDto eventDto)
        {

            UserEventType eventType;
            if (Enum.TryParse(eventDto.Type, out eventType))
            {
                Console.WriteLine($"Converted string to enum: {eventType}");
            }
            else
            {
                Console.WriteLine($"Failed to convert string to enum: {eventDto.Type}");
                Result<String> r = Result.Failure<String>(Error.Failure("CantCreateThisType", "there is no such type for you"));
                return NotFound(r.Value);

            }


            Result<string> response = await _calendarService.AddUserEvent(eventDto, User.GetUserId());
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            if(response.IsSuccess)
            return Ok(response.Value);
            else
             return BadRequest(response.Value);
            // return Ok();
        }

        [Authorize("IsAdmin")]
        [HttpPost("admin/calendar/event")]
        public async Task<object> AddAdminEvent([FromBody] CalendarEventDto eventDto)
        {
            AdminEventType eventType;
            if (Enum.TryParse(eventDto.Type, out eventType))
            {
                Console.WriteLine($"Converted string to enum: {eventType}");
            }
            else
            {
                Console.WriteLine($"Failed to convert string to enum: {eventDto.Type}");
                Result<String> r = Result.Failure<String>(Error.Failure("CantCreateThisType", "there is no such type for you"));
                return NotFound(r.Value);

            }

            Result<string> response = await _calendarService.AddUserEvent(eventDto, User.GetUserId());
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok(response.Value);
        }

        [HttpGet("users")]
        public async Task<object> GetUsers([FromQuery] string name="", [FromQuery] string role="")
        {
            Result<List<usersDTO>> response = await _calendarService.GetUsers(name,role);
            Console.WriteLine(response.Value);
            return Ok(response.Value);
        }
        [Authorize()]
        [HttpPost("calendar/events/{eventId}")]
        public async Task<object> AcceptOrRejectEvent(string eventId, [FromBody] ActionDto actionDto)
        {
            Result<string> response = await _calendarService.AcceptOrRejectEvent(eventId, actionDto.actionDto, User.GetUserId());
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok(response.Value);
        }

        [HttpGet("calendar/events")]
        [Authorize()]

        public async Task<object> GetEventsByMonth([FromQuery] string month)
        {


            //string userRole = User.GetUserRole();
            //Console.WriteLine("------------------------------------");
            //Console.WriteLine(userId.ToString());

            Result<CalendarMonthEventsDto> response = await _calendarService.GetEventsByMonth(month, User.GetUserId());
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok(response.Value);
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
        [HttpGet("MonthTimeAvailability")]
        public async Task<object>  GetMonthFreeTime([FromQuery] string month)
        {
            Result<CalendarMonthFreeTime> resp = await _calendarService.GetAvailabilityByMonth(month);
            //Console.WriteLine("-----------------");
            //foreach (var t in resp.Value.Days)
            //{
            //    Console.WriteLine("kolejna");
            //    foreach (var d in resp.Value.Days)
            //    foreach (var da in d.FreeTimeList)
            //            Console.WriteLine(da.Start.ToString() + "||" + da.End.ToString());
            //}
            return Ok(resp.Value);
        }
    }
}