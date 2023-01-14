using System.Text.Json.Serialization;

namespace RickAndMorty.Worker.JsonModels.Character;

public class SearchCharacterSchema
{
    [JsonPropertyName("info")]
    public Links Info { get; set; }
    
    [JsonPropertyName("results")]
    public CharacterSchema[] Characters { get; set; }
}