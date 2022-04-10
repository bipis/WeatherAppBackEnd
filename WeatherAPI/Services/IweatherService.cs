using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public interface IweatherService
    {
        Task<Weather> GetWeatherAsync(string town);
    }
}
