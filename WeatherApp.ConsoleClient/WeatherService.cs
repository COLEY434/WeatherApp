using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ConsoleClient
{
    internal class WeatherService
    {
        private readonly HttpClient _client;
        public WeatherService()
        {
            _client = new HttpClient();
        }

        internal object GetCityWeatherInformation(string country, string city)
        {
            
        }
    }
}
