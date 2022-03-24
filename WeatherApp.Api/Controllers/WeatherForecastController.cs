using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetCurrentWeather")]
        public async Task<IActionResult> GetWeather()
        {
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
