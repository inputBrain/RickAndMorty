using Microsoft.AspNetCore.Mvc;

namespace RickAndMorty.Host.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Produces("application/json")]
public abstract class AbstractClientController : ControllerBase
{
}