using System.Text.Json.Serialization;

namespace WeatherSettings.Model.WeatherModels.WeatherListModels;

public class WeatherListResponse
{
    [JsonPropertyName("list")]
    public List<WeatherList> WeatherList { get; set; }
    
    [JsonPropertyName("city")]
    public City City { get; set; }
    
    [JsonPropertyName("country")]
    public string Country { get; set; }
}
