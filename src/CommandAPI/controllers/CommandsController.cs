//using directives
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
[Route("api/commands")]
/// [ApiController] Attribute routing
/// [ApiController] Automatic HTTP error responses
/// [ApiController] Defualt Binding sources
/// [ApiController] Problem details for error status codes
[ApiController]

public class CommandsController : ControllerBase{

    /// [HTTPGET] is really just specifying which verb our action responds to.
    [HttpGet]

    /// Controller action
public ActionResult<IEnumerable<string>> Get()
{
    return new string[] {"this","is","hard","coded"};

}
}
}