using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
}
