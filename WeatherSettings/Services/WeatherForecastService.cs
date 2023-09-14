using System.Text.Json;
using WeatherSettings.Model.WeatherModels;
using WeatherSettings.Model.WeatherModels.WeatherListModels;
using WeatherSettings.Model.WeatherModels.WeatherSingleModels;

namespace WeatherSettings.Services;

public class WeatherForecastService
{
    private static async Task<T> GetWeatherData<T>(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode) throw new ArgumentException("Город не найден");

        var jsonApi = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(jsonApi);
    }

    public static async Task<WeatherListResponse> GetWeatherForecastWeek(string location) =>
        await GetWeatherData<WeatherListResponse>(OpenWeatherMapApi.GetWeek(location));

    public static async Task<WeatherListResponse> GetWeatherForecastWeek(LatLong latLong) =>
        await GetWeatherData<WeatherListResponse>(OpenWeatherMapApi.GetWeek(latLong));

    public static async Task<WeatherResponse> GetWeatherForecast(string location) =>
        await GetWeatherData<WeatherResponse>(OpenWeatherMapApi.GetUrl(location));

    public static async Task<WeatherResponse> GetWeatherForecast(LatLong latLong) =>
        await GetWeatherData<WeatherResponse>(OpenWeatherMapApi.GetUrl(latLong));
}