using System.Text.Json.Serialization;

namespace WeatherSettings.Model;

public class LocationResponse
{
    public string status { get; set; }
    public string country { get; set; }
    public string countryCode { get; set; }
    public string region { get; set; }
    public string regionName { get; set; }
    public string city { get; set; }
    public string zip { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string timezone { get; set; }
    public string isp { get; set; }
    [JsonPropertyName("as")]
    public string AS { get; set; }
    public string query { get; set; }
}