using System.Text.Json.Serialization;

namespace RickAndMorty.Worker.JsonModels.Character;

public class OriginSchema
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
}