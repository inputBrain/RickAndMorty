using Microsoft.AspNetCore.Mvc;

namespace RickAndMorty.Host.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    [Route("test_message")]
    public string ShowHello()
    {
        return new string("Hello");
    }
}