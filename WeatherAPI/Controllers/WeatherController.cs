using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Weather")]
    public class WeatherController : ApiController
    {
        public IweatherService WeatherServce { get; private set; }

        public WeatherController(IweatherService weatherService)
        {
            this.WeatherServce = weatherService;
        }

        [HttpGet]
        [Route("GetWeather/{town}")]
        public async Task<IHttpActionResult> GetWeather(string town)
        {
            try
            {
                var weather = await this.WeatherServce.GetWeatherAsync(town);
                return Ok(weather);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
