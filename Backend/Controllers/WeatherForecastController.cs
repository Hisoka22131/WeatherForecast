using Microsoft.AspNetCore.Mvc;
using WeatherSettings.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;


    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("get-weather-forecast")]
    public async Task<string> Get(string location = "") => $"Температура в {DateTime.UtcNow} равна {await WeatherForecastService.GetWeatherForecast(location)}\u00B0C";
}