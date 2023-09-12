using System.Text.Json.Serialization;

namespace WeatherSettings.Model.WeatherModels.WeatherSingleModels;

public class Main
{
    [JsonPropertyName("temp")]
    public float Temperature { get; set; }

    [JsonPropertyName("feels_like")]
    public float FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public float MinTemperature { get; set; }

    [JsonPropertyName("temp_max")]
    public float MaxTemperature { get; set; }

    public int Pressure { get; set; }
    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }

    [JsonPropertyName("grnd_level")]
    public int GroundLevel { get; set; }
}