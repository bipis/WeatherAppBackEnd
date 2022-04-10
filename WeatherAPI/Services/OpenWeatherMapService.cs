using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class OpenWeatherMapService : IweatherService
    {
        public string APIkey { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public OpenWeatherMapService()
        {
            this.HttpClient = new HttpClient();
            this.APIkey = "227f5449d3f733bd7d698253920ba2fb";
        }
        public async Task<Weather> GetWeatherAsync(string town)
        {
            this.HttpClient.BaseAddress = new Uri("http://api.openweathermap.org");
            var response = await HttpClient.GetAsync(@"/data/2.5/weather?q=" + town + "&appid=" + APIkey + "&units=metric");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return this.Map(JsonConvert.DeserializeObject<OpenWeather>(result));
            }
            else
            {
                throw new HttpException((int)response.StatusCode, result);
            }
        }

        private Weather Map(OpenWeather openWeather)
        {
            return new Weather()
            {
                TownName = openWeather.Name,
                Temperature = openWeather.Main.Temp,
                Description = openWeather.Weather.FirstOrDefault() != null ? openWeather.Weather.First().Main : string.Empty,
                Country = openWeather.Sys.Country
            };
        }
    }
}