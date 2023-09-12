using System.Text.Json.Serialization;
using WeatherSettings.Model.WeatherModels.WeatherSingleModels;

namespace WeatherSettings.Model.WeatherModels.WeatherListModels;

public class City
{
    [JsonPropertyName("city")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("coord")]
    public Coord Coord { get; set; }
}