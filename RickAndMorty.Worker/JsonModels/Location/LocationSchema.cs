using System.Text.Json.Serialization;

namespace RickAndMorty.Worker.JsonModels.Location;

public class LocationSchema
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
}