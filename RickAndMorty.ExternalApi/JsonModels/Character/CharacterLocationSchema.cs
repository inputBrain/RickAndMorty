using System.Text.Json.Serialization;

namespace RickAndMorty.ExternalApi.JsonModels.Character;

public class CharacterLocationSchema
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
}