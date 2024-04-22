//using Microsoft.AspNetCore.Mvc;

//namespace My_Place_Backend.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

// private readonly ILogger<WeatherForecastController> _logger;

// public WeatherForecastController(ILogger<WeatherForecastController> logger) { _logger = logger; }

//        [HttpGet(Name = "GetWeatherForecast")]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                TemperatureC = Random.Shared.Next(-20, 55),
//                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }
//        [HttpPost]
//        public void Add()
//        {
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Infrastructure.Repositories; // Importing Repository
using Microsoft.Extensions.Logging;
using Domain;
using Domain.Repositories;

namespace My_Place_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<WeatherForecast> _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<WeatherForecast> weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var forecasts = _weatherForecastRepository.GetAll();
            return Ok(forecasts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var forecast = _weatherForecastRepository.Get(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }

        [HttpPost("Add")]
        public IActionResult Add(WeatherForecast forecast)
        {
            _weatherForecastRepository.Add(forecast);
            return Ok();
        }
    }
}