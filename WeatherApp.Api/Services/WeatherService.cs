using System;
using System.Threading.Tasks;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<object> GetCurrentWeatherInfo(string city)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetWeather(string city)
        {
            throw new NotImplementedException();
        }

        public int MultiplyNumber(int a, int b)
        {
            return a * b;
        }
    }
}
