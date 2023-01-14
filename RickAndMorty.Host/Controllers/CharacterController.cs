using Microsoft.AspNetCore.Mvc;
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
    public async Task<object> GetCharacterByName(string name)
    {
        var dataJson = await Execute<SearchCharacterSchema>($"/character/?name={name}");
        // if (dataJson.Info.Count == 0)
        // {
        //     return $"Not found any characters. Count: {dataJson.Info.Count}";
        // }


        return new OkResult(dataJson.Characters.Select(
            x =>
            {
                new SearchCharacterSchema()
                {
                    Characters = new CharacterSchema[]
                    {
                        new CharacterSchema()
                        {
                            Name = x.Name,
                            Status = x.Status,
                            Species = x.Species,
                            Gender = x.Gender,
                            Origin = new OriginSchema()
                            {
                                Name = x.Origin.Name
                            },
                            Type = x.Type,
                            
                        }
                    }
                };
            }
        ).ToList());


    }

    //string name = "Rick Sanchez", string episode = "S01E01"
    [HttpPost]
    public async Task<object> CheckCharacter(string name, string episode)
    {
        var searchedCharacters = await Execute<SearchCharacterSchema>($"/character/?name={name}");
        if (searchedCharacters.Info.Count == 0)
        {
            return $"Not found any characters. Count: {searchedCharacters.Info.Count}";
        }
        
        var searchedEpisodes = await Execute<SearchEpisodeSchema>($"/episode/?episode={episode}");
        if (searchedEpisodes.Info.Count == 0)
        {
            return $"Not found any episodes. Count: {searchedEpisodes.Info.Count}";

        }

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