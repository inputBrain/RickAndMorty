using System.Text.Json.Serialization;

namespace RickAndMorty.ExternalApi.JsonModels.Location;

public class LocationDataModel
{
    [JsonPropertyName("info")]
    public Links Info { get; set; }
    
    [JsonPropertyName("results")]
    public LocationSchema[] Results { get; set; }
}