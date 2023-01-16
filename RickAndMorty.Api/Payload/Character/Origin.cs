using System.ComponentModel.DataAnnotations;

namespace RickAndMorty.Api.Payload.Character;

public class Origin
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public string Dimension { get; set; }
}