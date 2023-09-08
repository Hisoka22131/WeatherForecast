namespace WeatherSettings.Model.Weather;

public class WeatherResponse
{
    public current current { get; set; }
    public request request { get; set; }
    public location location { get; set; }
}