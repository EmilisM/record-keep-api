using Microsoft.AspNetCore.Mvc;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("values");
        }
    }
}
