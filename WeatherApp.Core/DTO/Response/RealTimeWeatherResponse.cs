using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.DTO.Response
{
    public class RealTimeWeatherResponse
    {
        public Location location { get; set; }
        public Current current { get; set; }      
    }
    
    public class Current
    {
        public Condition condition { get; set; }
        public decimal temp_c { get; set; }
        public decimal temp_f { get; set; }
        public int last_updated_epoch { get; set; }
        public string last_updated { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal feelslike_f { get; set; }
        public int is_day { get; set; }
        public decimal wind_mph { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
    }
    public class Location
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public string localtime { get; set; }
    }

    public class Condition
    {
        public int code { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
    }
}
