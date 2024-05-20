using Api.Interfaces;
using Api.Services;
using Domain;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using My_Place_Backend.DTO.AccountManagment;
//using Domain.Calendar;
using static Domain.Calendar;
using static Domain.Models.Calendar.CalendarModels;
using Web.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using My_Place_Backend.Authorization;
using Microsoft.AspNetCore.Authorization;
using Domain.IRepositories;
using System.Security.Cryptography.Xml;


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

        [HttpPost("user/calendar/event")]
        public async Task<object> AddUserEvent([FromBody] CalendarEventDto eventDto)
        {
            Result<string> response = await _calendarService.AddUserEvent(eventDto);
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok(response.Value);
           // return Ok();
        }

        [HttpPost("admin/calendar/event")]
        public async Task<object> AddAdminEvent([FromBody] CalendarEventDto eventDto)
        {

            Result<string> response = await _calendarService.AddUserEvent(eventDto);
            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            return Ok(response.Value);
        }

        [HttpGet("users")]
        public IActionResult GetUsers([FromQuery] string name, [FromQuery] string role)
        {
            Result<string> response = _calendarService.GetUsers();
            Console.WriteLine("--------------");
            Console.WriteLine(response.Value);
            return Ok(response.Value);
        }

        [HttpPost("calendar/events/{eventId}")]
        public async Task<object> AcceptOrRejectEvent( string eventId, [FromBody] ActionDto actionDto)
        {
            Result<string> response = await _calendarService.AcceptOrRejectEvent(eventId, actionDto.actionDto);
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

            Guid userId = User.GetUserId();
            //string userRole = User.GetUserRole();
            //Console.WriteLine("------------------------------------");
            //Console.WriteLine(userId.ToString());

            Result<CalendarMonthEventsDto> response = await _calendarService.GetEventsByMonth(month,userId.ToString());
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
