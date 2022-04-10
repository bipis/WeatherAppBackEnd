using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public string TownName { get; set; }
        public string Country { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
    }
}