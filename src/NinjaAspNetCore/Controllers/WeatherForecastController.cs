using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace NinjaAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly LoggingAmoo _loggingAmoo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , IOptions<LoggingAmoo> loggingOptions)
        {
            _logger = logger;
            _loggingAmoo = loggingOptions.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}