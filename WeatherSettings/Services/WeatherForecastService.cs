using System.Text.Json;
using WeatherSettings.Model;
using WeatherSettings.Model.Weather;

namespace WeatherSettings.Services;

public class WeatherForecastService
{
    /// <summary>
    /// Ключ для получения доступу к погоде
    /// </summary>
    private static readonly string _apiKey = "7bad9134c824b5b39b213d941da89017";

    /// <summary>
    /// URL запрос для получения погоды
    /// </summary>
    private static string _weatherApiUrl = $"http://api.weatherstack.com/current?access_key={_apiKey}&query=";

    /// <summary>
    /// URL запрос для получения города по IP
    /// </summary>
    private static string _cityApiUrl = "http://ip-api.com/json/";

    public static async Task<string> GetWeatherForecast(string location)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(await GetUrl(location));
        
        if (!response.IsSuccessStatusCode) return "Город не найден";

        var jsonApi = await response.Content.ReadAsStringAsync();
        
        var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(jsonApi);
        
        return weatherResponse.current.temperature.ToString();
    }

    /// <summary>
    /// Получение данных о погоде
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    private static async Task<string> GetUrl(string location)
    {
        if (string.IsNullOrEmpty(location))
            return _weatherApiUrl + await GetCurrentCity();

        return _weatherApiUrl + location;
    }

    /// <summary>
    /// Получение города теущего пользователя
    /// </summary>
    /// <returns></returns>
    public static async Task<string> GetCurrentCity()
    {
        var userIp = await IpService.GetUserIp();

        var apiUrl = _cityApiUrl + userIp;

        using var client = new HttpClient();

        var jsonApi = await client.GetStringAsync(apiUrl);

        var locationResponse = JsonSerializer.Deserialize<LocationResponse>(jsonApi);

        return locationResponse.city;
    }
}