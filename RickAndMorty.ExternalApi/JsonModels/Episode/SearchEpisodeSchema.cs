using System.Text.Json.Serialization;

namespace RickAndMorty.ExternalApi.JsonModels.Episode;

public class SearchEpisodeSchema
{
    [JsonPropertyName("info")]
    public Links Info { get; set; }
    
    [JsonPropertyName("results")]
    public EpisodeSchema[] Episodes { get; set; }
}