using System.Text.Json.Serialization;
using RickAndMorty.Worker.JsonModels.Location;

namespace RickAndMorty.Worker.JsonModels.Character;

public class CharacterSchema
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("species")]
    public string Species { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    
    [JsonPropertyName("origin")]
    public OriginSchema Origin { get; set; }
    
    [JsonPropertyName("location")]
    public LocationSchema Location { get; set; }
    
    [JsonPropertyName("image")]
    public string Image { get; set; }
    
    // TODO:
    [JsonPropertyName("episode")]
    public string[] Episodes { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("created")]
    public string Created { get; set; }
}