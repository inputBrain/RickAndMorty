using System.ComponentModel.DataAnnotations;

namespace RickAndMorty.Api.Payload.Character;

public class Character
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string Species { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public Origin.Origin Origin { get; set; }

    [Required]
    public string Type { get; set; }
    
    [Required]
    public Location.Location Location { get; set; }
}