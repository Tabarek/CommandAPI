//using directives
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data; //1
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/commands")]
    /// [ApiController] Attribute routing
    /// [ApiController] Automatic HTTP error responses
    /// [ApiController] Defualt Binding sources
    /// [ApiController] Problem details for error status codes
    [ApiController]

    public class CommandsController : ControllerBase {

        private readonly ICommandAPIRepo _repositry; //2

        public CommandsController(ICommandAPIRepo repositry) //3&4
        {
            _repositry = repositry;//5
        }

        /// [HTTPGET] is really just specifying which verb our action responds to.
        [HttpGet]

        /// Controller action
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repositry.GetAllCommands();
            return Ok(commandItems);

        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Command>> GetCommandById(int id)
        {
            var commandItem = _repositry.GetCommandById(id);
            if(commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }

        

    


}
}


//1: Add new using statment to the reference
//2: [_repositry] will be assigned the injected MockCommand
//3: [public CommandsController(ICommandAPIRepo repositry] the class will be calle dwhen you interdting to make use of our Controller
//4:
//5: