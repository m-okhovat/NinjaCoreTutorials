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
            //, IOptionsSnapshot<LoggingAmoo> loggingOptions
            , LoggingAmoo loggingAmoo
            )
        {
            _logger = logger;
            // _loggingAmoo = loggingOptions.Value;
            _loggingAmoo = loggingAmoo;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                // do something
                _logger.LogInformation("method started.");
            }
            catch (Exception e ) //silent catch 
            {
                
                _logger.LogError(e, "");
                
            }
            return Ok();
        }
    }
}