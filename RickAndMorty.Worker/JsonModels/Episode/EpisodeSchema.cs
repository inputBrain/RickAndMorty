using System.Text.Json.Serialization;

namespace RickAndMorty.Worker.JsonModels.Episode;

public class EpisodeSchema
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("air_date")]
    public string Air_date { get; set; }
    
    [JsonPropertyName("episode")]
    public string Episode { get; set; }
    
    [JsonPropertyName("characters")]
    public string[] Characters { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("created")]
    public string Created { get; set; }
}