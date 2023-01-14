using System.ComponentModel.DataAnnotations;

namespace RickAndMorty.Api.Payload.Location;

public class Location
{
    [Required]
    public string Dimension { get; set; }
}