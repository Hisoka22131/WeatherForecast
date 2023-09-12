using Microsoft.AspNetCore.Mvc;
using WeatherSettings;
using WeatherSettings.Model.WeatherModels.WeatherListModels;
using WeatherSettings.Model.WeatherModels.WeatherSingleModels;
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
    public async Task<WeatherResponse> GetToday(string location = "") => await WeatherForecastService.GetWeatherForecast(location);
    
    [HttpPost]
    [Route("get-weather-forecast-latLong")]
    public async Task<WeatherResponse> GetLatLongToday(OpenWeatherMapApi.LatLong latLong) => await WeatherForecastService.GetWeatherForecast(latLong);
    
    [HttpGet]
    [Route("get-weather-forecast-week/{location}")]
    public async Task<WeatherListResponse> GetWeek(string location = "") => await WeatherForecastService.GetWeatherForecastWeek(location);
    
    [HttpPost]
    [Route("get-weather-forecast-latLong-week")]
    public async Task<WeatherListResponse> GetLatLongWeek(OpenWeatherMapApi.LatLong latLong) => await WeatherForecastService.GetWeatherForecastWeek(latLong);
}