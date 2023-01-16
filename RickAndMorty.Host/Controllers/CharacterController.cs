using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Api.Character;
using RickAndMorty.Api.Payload.Character;
using RickAndMorty.Host.Services;
using RickAndMorty.ExternalApi.JsonModels.Character;
using RickAndMorty.ExternalApi.JsonModels.Episode;
using RickAndMorty.ExternalApi.JsonModels.Location;

namespace RickAndMorty.Host.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Produces("application/json")]
public class CharacterController : BaseParser
{
    [HttpGet]
    public async Task<object> GetOneCharacterById(int id)
    {
        return await Execute<CharacterSchema>($"/character/{id}");
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetList.Response), 200)]
    public async Task<GetList.Response> GetCharacterByName(string name)
    {
        var dataJson = await Execute<SearchCharacterSchema>($"/character/?name={name}");

        return new GetList.Response
        {
            Characters = dataJson.Characters.Select(x => 
                new Character 
                {
                    Name = x.Name,
                    Status = x.Status,
                    Species = x.Species,
                    Type = x.Type,
                    Gender = x.Gender,
                    Origin = new Origin
                    {
                        Name = x.Origin.Name,
                        Type = x.Origin.Url,
                        Dimension = Execute<LocationDataModel>($"/location/?name={x.Location.Name}").Result.Results.First().Dimension
                    },
                }
            ).ToArray()
        };
    }

    [HttpPost]
    public async Task<object> CheckCharacter(string name, string episode)
    {
        var searchedCharacters = await Execute<SearchCharacterSchema>($"/character/?name={name}");

        var searchedEpisodes = await Execute<SearchEpisodeSchema>($"/episode/?episode={episode}");

        
        foreach (var characterEpisodes in searchedCharacters.Characters.Select(x => x.Episodes))
        {
            foreach (var episodeSchema in searchedEpisodes.Episodes)
            {
                if (characterEpisodes.Contains(episodeSchema.Url))
                {
                    return true;
                }
            }
        }
        return false;
    }
}