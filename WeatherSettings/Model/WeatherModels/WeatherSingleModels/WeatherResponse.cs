using System.Text.Json.Serialization;

namespace WeatherSettings.Model.WeatherModels.WeatherSingleModels;

public class WeatherResponse
{
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cod")]
    public int Cod { get; set; }
    
    [JsonPropertyName("coord")]
    public Coord Coord { get; set; }
    
    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }
    
    [JsonPropertyName("main")]
    public Main Main { get; set; }
    
    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }
}