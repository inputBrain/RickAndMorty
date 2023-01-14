using System.ComponentModel.DataAnnotations;

namespace RickAndMorty.Api.Payload.Origin;

public class Origin
{
    [Required]
    public string Name { get; set; }
}