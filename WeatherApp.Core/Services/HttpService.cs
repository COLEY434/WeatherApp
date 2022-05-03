using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Core.DTO.Response;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Core.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public HttpService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["ApiKey"];
            string baseUrl = config["WeatherBaseUrl"];
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<RealTimeWeatherResponse> FetchWeatherInfo(string searchParam)
        {
            string relativeUrl = "current.json";

            var response = await _httpClient.GetStringAsync(relativeUrl + $"?key={_apiKey}&q={searchParam}");
            var result = JsonSerializer.Deserialize<RealTimeWeatherResponse>(response);

            return result;
        }

    }
}
