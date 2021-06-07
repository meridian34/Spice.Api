using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpiceController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public SpiceController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                
            })
            .ToArray();
        }
    }
}
