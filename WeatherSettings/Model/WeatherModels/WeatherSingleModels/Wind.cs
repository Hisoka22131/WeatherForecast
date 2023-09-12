using System.Text.Json.Serialization;

namespace WeatherSettings.Model.WeatherModels.WeatherSingleModels;

public class Wind
{
    [JsonPropertyName("speed")]
    public decimal Speed { get; set; }
    
    [JsonPropertyName("deg")]
    public int Deg { get; set; }
    
    [JsonPropertyName("gust")]
    public decimal Gust { get; set; }
}