using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace RickAndMorty.Host.Services;

public class BaseParser
{
    // https://rickandmortyapi.com/api/episode
    private const string BaseUrl = "https://rickandmortyapi.com/api";
    private readonly HttpClient _client;

    
    protected BaseParser()
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl)
        };
    }
    

    async protected Task<T> Execute<T>(string action) where T : new()
    {
        var response = await _client.GetAsync(BaseUrl + action);

        var jsonData = await response.Content.ReadAsStreamAsync();


        return await JsonSerializer.DeserializeAsync<T>(jsonData, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = false
        });
    }
    
    async protected Task<T> ExecuteWithParams<T>(string action, IDictionary<string, string> paramsData) where T : new()
    {
        var response = await _client.GetAsync(QueryHelpers.AddQueryString(BaseUrl + action, paramsData));

        var jsonData = await response.Content.ReadAsStreamAsync();


        return await JsonSerializer.DeserializeAsync<T>(jsonData, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = false
        });
    }
}