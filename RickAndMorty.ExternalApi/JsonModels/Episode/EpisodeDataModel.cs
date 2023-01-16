using System.Text.Json.Serialization;

namespace RickAndMorty.ExternalApi.JsonModels.Episode;

public class EpisodeDataModel
{
    [JsonPropertyName("info")]
    public Links Info { get; set; }
    
    [JsonPropertyName("results")]
    public EpisodeSchema[] Results { get; set; }
}