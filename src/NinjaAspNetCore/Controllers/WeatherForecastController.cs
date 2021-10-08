using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace NinjaAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {

                using (_logger.BeginScope("ScopeA"))
                using (_logger.BeginScope(new Dictionary<string, object>() { { "value", 123 } }))
                {
                    // Step A:
                    _logger.LogInformation("first step ");

                    _logger.LogInformation("first step 2 ");

                    _logger.LogInformation("first step 3 ");

                    _logger.LogInformation("first step 4 ");

                }


                try
                {
                    try
                    {
                        // _logger.LogInformation("first step ");

                        // _logger.LogInformation("first step 2 ");

                        // _logger.LogInformation("first step 3 ");

                        // _logger.LogInformation("first step 4 ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                // Step B:

                //Step C:

            }
            catch (Exception e) //silent catch 
            {

                _logger.LogError(e, "");

            }
            return Ok();
        }
    }


    public interface IBird
    {
        void Sound();
    }

    public class Dock : IBird
    {
        public void Sound()
        {
            Console.WriteLine("Quak");
        }
    }

    public class Hen : IBird
    {
        public void Sound()
        {
            Console.WriteLine("Kod");
        }
    }

    public class Consumer
    {
        private IBird _bird;

        public Consumer(IBird bird)
        {
            _bird = bird;
        }

        public void Do()
        {
            _bird.Sound();
        }
    }

    //****************

    public class DogAdapter : IBird
    {
        private Dog _dog = new Dog();

        public DogAdapter(IConfiguration configuration)
        {
        }

        public void Sound()
        {
            _dog.Voice();
        }
    }

    // ******************
    public interface IAnimal
    {
        public void Voice();
    }

    public class Dog : IAnimal
    {
        public void Voice()
        {
            Console.WriteLine("HOp HOp");
        }
    }
}