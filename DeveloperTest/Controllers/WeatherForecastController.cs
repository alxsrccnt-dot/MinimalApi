using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "";
        }
    }
}
