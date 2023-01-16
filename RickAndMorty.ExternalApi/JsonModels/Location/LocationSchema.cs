using System.Text.Json.Serialization;

namespace RickAndMorty.ExternalApi.JsonModels.Location;

public class LocationSchema
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
}