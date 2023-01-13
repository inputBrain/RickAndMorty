using System.Text.Json.Serialization;

namespace RickAndMorty.Worker.JsonModels.Episode;

public class EpisodeDataModel
{
    [JsonPropertyName("info")]
    public Links Info { get; set; }
    
    [JsonPropertyName("results")]
    public EpisodeData[] Results { get; set; }
}