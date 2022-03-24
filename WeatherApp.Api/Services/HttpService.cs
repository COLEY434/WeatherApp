using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp.Api.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public HttpService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config.GetValue<string>("ApiKey");
            string baseUrl = config.GetValue<string>("WeatherBaseUrl");
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<object> GetCurrentWeather(string city)
        {
            string relativeUrl = "current.json";

            var response = await _httpClient.GetStringAsync(relativeUrl + $"key={_apiKey}&q={city}");
            var result = JsonSerializer.Deserialize<dynamic>(response);

            return result;
        }

       
    }
}
