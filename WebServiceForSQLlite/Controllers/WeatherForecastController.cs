using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebServiceForSQLlite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherContext _weatherContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherContext weatherContext)
        {
            _logger = logger;
            _weatherContext = weatherContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weather = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 56,
                Summary = Summaries[1]
            };

            _weatherContext.Add(weather);
            //_weatherContext.SaveChangesAsync();

            //var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => weather)
            .ToArray();

            
        }
    }
}
