using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Api.Controllers
{
    [ApiController]
    [Route("api/WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("GetCurrentWeather/{searchParam}")]
        public async Task<IActionResult> GetCurrentWeather([FromRoute] string searchParam)
        {
         
            try
            {
                var result = await _weatherService.GetCurrentWeatherAsync(searchParam);

                if(result == null)
                {
                    return Ok("No current weather information to display");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured getting current weather information for {searchParam}");
                return StatusCode(500, "An error occurred while getting weather information");
            }            
           
        }


    }
}
