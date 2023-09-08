using System.Text.Json;
using WeatherSettings.Model;

namespace WeatherSettings.Services;

public static class IpService
{
    /// <summary>
    /// Сайт для получения IP адреса
    /// </summary>
    private const string ApiUrl = "https://api.ipify.org?format=json";

    /// <summary>
    /// Получение IP адреса пользователя
    /// </summary>
    /// <returns></returns>
    internal static async Task<string> GetUserIp()
    {
        using var client = new HttpClient();

        var jsonApi = await client.GetStringAsync(ApiUrl);
        
        var response = JsonSerializer.Deserialize<IpResponse>(jsonApi);

        return response.ip;
    }
}