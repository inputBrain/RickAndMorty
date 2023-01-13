using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Host.Services;
using RickAndMorty.Worker.JsonModels.Episode;

namespace RickAndMorty.Host.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Produces("application/json")]
public class EpisodeController : BaseParser
{
    
    [HttpGet]
    public async Task<object> GetOneEpisode(int id)
    {
        var dataJson = await Execute<EpisodeData>($"/episode/{id}");

        //TODO: 
        if (dataJson.Id == 0)
        {
            return $"404. Episode with id: {id} not found.";
        }
        return dataJson;
    }
    
    
    [HttpGet]
    public async Task<object> GetAllEpisodes()
    {
        var dataJson = await Execute<EpisodeDataModel>("/episode");
        
        return dataJson;
    }

    //TODO: need to fix it
    [HttpGet]
    public async Task<object> GetMultipleEpisode(int[] ids)
    {
        var dataJson = await Execute<EpisodeData>($"/episode/{string.Join(",", ids)}");

        //TODO: fix it
        if (dataJson.Id == 0)
        {
            return $"404. Episode with id: {ids} not found.";
        }
        return dataJson;
    }
}