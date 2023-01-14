using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Api.Character;
using RickAndMorty.Api.Payload.Character;
using RickAndMorty.Api.Payload.Location;
using RickAndMorty.Api.Payload.Origin;
using RickAndMorty.Host.Services;
using RickAndMorty.Worker.JsonModels.Character;
using RickAndMorty.Worker.JsonModels.Episode;

namespace RickAndMorty.Host.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Produces("application/json")]
public class CharacterController : BaseParser
{
    [HttpGet]
    public async Task<object> GetOneCharacterById(int id)
    {
        var dataJson = await Execute<CharacterSchema>($"/character/{id}");

        if (dataJson.Id == 0)
        {
            return $"404. Character with id: {id} not found.";
        }

        return dataJson;
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
                        Gender = x.Gender,
                        Type = x.Type,
                        Origin = new Origin
                        {
                            Name = x.Origin.Name,
                        },
                        Location = new Location
                        {
                            Dimension = x.Location.Name
                        }

                    }
                )
                .ToArray()
        };
    }

    //string name = "Rick Sanchez", string episode = "S01E01"
    [HttpPost]
    public async Task<object> CheckCharacter(string name, string episode)
    {
        var searchedCharacters = await Execute<SearchCharacterSchema>($"/character/?name={name}");

        var searchedEpisodes = await Execute<SearchEpisodeSchema>($"/episode/?episode={episode}");

        
        foreach (var characterEpisodes in searchedCharacters.Characters.Select(x => x.Episodes))
        {
            foreach (var episodeSchema in searchedEpisodes.Episodes)
            {
                //TODO:
                if (characterEpisodes.Contains(episodeSchema.Url))
                {
                    return true;
                }
            }
        }
        return false;
    }
}