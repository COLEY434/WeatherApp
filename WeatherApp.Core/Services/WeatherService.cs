using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.DTO.Response;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(IHttpService httpService, ILogger<WeatherService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }
        public async Task<RealTimeWeatherResponse> GetCurrentWeatherAsync(string searchParam)
        {
            if (string.IsNullOrWhiteSpace(searchParam))
            {
                return null;
            }

            _logger.LogInformation($"Getting current weather information for {searchParam}");

            var result = await _httpService.FetchWeatherInfo(searchParam);

            if(result == null)
            {
                return null;
            }

            return result;
        }
    }
}
