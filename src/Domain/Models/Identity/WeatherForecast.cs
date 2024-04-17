using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity
{
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }

        public int TemperatureC { get; set; }
    }
}