using System.Text.Json.Serialization;
using WeatherSettings.Model.WeatherModels.WeatherSingleModels;

namespace WeatherSettings.Model.WeatherModels.WeatherListModels;

public class WeatherList
{
    [JsonPropertyName("weather")]
    public List<Weather> Weather { get; set; }
    
    [JsonPropertyName("main")]
    public Main Main { get; set; }
    
    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }
    
    [JsonPropertyName("dt_txt")]
    public string DateTxt { get; set; }
}