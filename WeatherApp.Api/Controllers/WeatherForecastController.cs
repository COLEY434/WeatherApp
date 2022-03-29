using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Api.Services.Interfaces;

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

        [HttpGet("GetCurrentWeather/{input}")]
        public async Task<IActionResult> GetCurrentWeather([FromRoute] string input)
        {
            string ip = "84958232";
            _logger.LogInformation($"Getting current weather information for {ip}");

            bool isValid  = Utils.IsInputValid(input);

            if (!isValid)
            {
                return BadRequest("Invalid Input");
            }

           // var result = await _weatherService.GetWeather(input);
            var http = new HttpClient();

            //var req = new { key = "ff8353b21f6c44e985f200928220202", q = "Lagos"};

            //var content = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json");

            try
            {
                var url = "https://api.weatherapi.com/v1/current.json?key=" + "ff8353b21f6c44e985f200928220202" + $"&q=Lagos";
                var response = await http.GetAsync(url);
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<dynamic>(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured getting current weather info");
                return BadRequest(ex.Message);
            }            
           
        }


    }
}
