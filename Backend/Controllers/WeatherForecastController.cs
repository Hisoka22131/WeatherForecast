using Microsoft.AspNetCore.Mvc;
using WeatherSettings.Model.Weather;
using WeatherSettings.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    
    private readonly ILogger<WeatherForecastController> _logger;
    
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("get-weather-forecast/{location}")]
    public async Task<WeatherResponse> Get(string location = "") => await WeatherForecastService.GetWeatherForecast(location);
}