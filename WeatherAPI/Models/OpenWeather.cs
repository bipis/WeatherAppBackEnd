using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI.Models
{
    public class OpenWeather
    {
        public string Name { get; set; }
        public IEnumerable<OpenWeatherDescription> Weather { get; set; }
        public OpenWeatherMain Main { get; set; }
        public OpenWeatherLocation Sys { get; set; }
    }
}