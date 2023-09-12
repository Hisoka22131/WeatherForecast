using System.Text.Json;
using WeatherSettings.Model.WeatherModels.WeatherListModels;
using WeatherSettings.Model.WeatherModels.WeatherSingleModels;

namespace WeatherSettings.Services;

public class WeatherForecastService
{
    public static async Task<WeatherListResponse> GetWeatherForecastWeek(string location)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(OpenWeatherMapApi.GetWeek(location));
        
        if (!response.IsSuccessStatusCode) throw new ArgumentException("Город не найден");

        var jsonApi = await response.Content.ReadAsStringAsync();
        
        var weatherListResponse = JsonSerializer.Deserialize<WeatherListResponse>(jsonApi);
        
        return weatherListResponse;
    }
    
    public static async Task<WeatherListResponse> GetWeatherForecastWeek(OpenWeatherMapApi.LatLong latLong)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(OpenWeatherMapApi.GetWeek(latLong));
        
        if (!response.IsSuccessStatusCode) throw new ArgumentException("Город не найден");

        var jsonApi = await response.Content.ReadAsStringAsync();
        
        var weatherListResponse = JsonSerializer.Deserialize<WeatherListResponse>(jsonApi);
        
        return weatherListResponse;
    }
    
    public static async Task<WeatherResponse> GetWeatherForecast(string location)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(OpenWeatherMapApi.GetUrl(location));
        
        if (!response.IsSuccessStatusCode) throw new ArgumentException("Город не найден");

        var jsonApi = await response.Content.ReadAsStringAsync();
        
        var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(jsonApi);
        
        return weatherResponse;
    }
    
    public static async Task<WeatherResponse> GetWeatherForecast(OpenWeatherMapApi.LatLong latLong)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(OpenWeatherMapApi.GetUrl(latLong));
        
        if (!response.IsSuccessStatusCode) throw new ArgumentException("Город не найден");

        var jsonApi = await response.Content.ReadAsStringAsync();
        
        var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(jsonApi);
        
        return weatherResponse;
    }
}