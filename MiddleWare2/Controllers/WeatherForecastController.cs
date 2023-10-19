using Microsoft.AspNetCore.Mvc;

namespace MiddleWare2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Weather")]
        public IActionResult Get()
        {
            throw new Exception("Error bro");
        }
        [HttpGet]
        public IActionResult Getdata(int id)
        {
            throw new Exception("Dada");
        }
    }
}