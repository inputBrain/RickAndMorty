using System.Text.Json.Serialization;

namespace RickAndMorty.Worker.JsonModels.Episode;

public class SearchEpisodeSchema
{
    [JsonPropertyName("info")]
    public Links Info { get; set; }
    
    [JsonPropertyName("results")]
    public EpisodeSchema[] Episodes { get; set; }
}