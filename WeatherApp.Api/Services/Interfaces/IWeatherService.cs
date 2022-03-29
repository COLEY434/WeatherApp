using System.Threading.Tasks;

namespace WeatherApp.Api.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<object> GetWeather(string city);
    }
}
