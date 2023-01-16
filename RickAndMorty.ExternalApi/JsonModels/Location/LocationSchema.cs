using System.Text.Json.Serialization;

namespace RickAndMorty.ExternalApi.JsonModels.Location;

public class LocationSchema
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("dimension")]
    public string Dimension { get; set; }
    
    [JsonPropertyName("residents")]
    public string[] Residents { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("created")]
    public string Created { get; set; }
}