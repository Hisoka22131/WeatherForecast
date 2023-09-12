using System.Text.Json.Serialization;

namespace WeatherSettings.Model.WeatherModels.WeatherSingleModels;

public class Coord
{
    [JsonPropertyName("lon")]
    public decimal Lon { get; set; }
    
    [JsonPropertyName("lat")]
    public decimal Lat { get; set; }
}