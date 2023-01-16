using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Host.Services;
using RickAndMorty.ExternalApi.JsonModels.Episode;

namespace RickAndMorty.Host.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Produces("application/json")]
public class EpisodeController : BaseParser
{
    
    [HttpGet]
    public async Task<object> GetOneEpisode(int id)
    {
       return await Execute<EpisodeSchema>($"/episode/{id}");
    }
    
    
    [HttpGet]
    public async Task<object> GetAllEpisodes()
    {
        return await Execute<EpisodeDataModel>("/episode");
    }
}