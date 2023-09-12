namespace WeatherSettings;

public static class OpenWeatherMapApi
{
    private static string ApiKey = "963f1b6e0ba636fb33872aa9677dbeac";

    public static string GetUrl(string city) =>
        $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang=ru&APPID={ApiKey}";

    public static string GetUrl(LatLong latLong) =>
        $"https://api.openweathermap.org/data/2.5/weather?lat={latLong.Latitude}&lon={latLong.longitude}&units=metric&lang=ru&appid={ApiKey}";

    public static string GetWeek(string city) =>
        $"https://api.openweathermap.org/data/2.5/forecast?q={city}&cnt=7&units=metric&lang=ru&APPID={ApiKey}";
    
    public static string GetWeek(LatLong latLong) =>
        $"https://api.openweathermap.org/data/2.5/forecast?lat={latLong.Latitude}&lon={latLong.longitude}&cnt=7&units=metric&lang=ru&APPID={ApiKey}";

    public class LatLong
    {
        public decimal Latitude { get; set; }

        public decimal longitude { get; set; }
    }
}