using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.DTO.Response;

namespace WeatherApp.Core.Interfaces
{
    public interface IWeatherService
    {
        Task<RealTimeWeatherResponse> GetCurrentWeatherAsync(string searchParam);
    }
}
