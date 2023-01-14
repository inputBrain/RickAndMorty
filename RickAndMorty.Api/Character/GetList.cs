using System.ComponentModel.DataAnnotations;

namespace RickAndMorty.Api.Character;

public sealed class GetList
{
    public sealed class Response
    {
        public Payload.Character.Character[] Characters { get; set; }
    }
}