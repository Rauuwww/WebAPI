using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (ListWeatherForecast == null || !ListWeatherForecast.Any())
            {
                ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Route("Get/weatherforecast")]
        [Route("Get/weatherforecast2")]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> GetW()
        {
            _logger.LogDebug("Retornando la lista de weatherforecast");
            return ListWeatherForecast;
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            ListWeatherForecast.Add(weatherForecast);

            return Ok();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= ListWeatherForecast.Count)
            {
                return NotFound(); // Devolver 404 si el �ndice est� fuera de rango
            }

            ListWeatherForecast.RemoveAt(index);

            return Ok();
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, WeatherForecast updatedForecast)
        {
            if (index < 0 || index >= ListWeatherForecast.Count)
            {
                return NotFound(); // Devolver 404 si el �ndice est� fuera de rango
            }

            // Actualizar el elemento en la posici�n especificada
            ListWeatherForecast[index] = updatedForecast;

            return Ok();
        }
    }
}
