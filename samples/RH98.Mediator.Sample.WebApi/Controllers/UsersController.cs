using Microsoft.AspNetCore.Mvc;
using RH98.Mediator.Sample.WebApi.Features;

namespace RH98.Mediator.Sample.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var query = new ListUsersQuery();

        var result = await mediator.Send(query);

        return Ok(result);
    }
}
