using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Services;
using Paperboy.Api.Dtos;
using Paperboy.Api.Data.Models;

// TODO: Get bot Stats endpoint
// TODO: Update bot endpoint
// TODO: Delete bot endpoint

namespace Paperboy.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private BotService _botService;

        public BotController(BotService botService) 
        {
            _botService = botService;
        }
        // Create New Bot
        [HttpPost("Create")]
        IActionResult CreateBot()
        {
            Bot _bot = _botService.CreateNewBot();
            return Ok("Hello World");
        }

        // TODO: Get bot Stats endpoint
        [HttpGet("Report")]
        IActionResult GetBotStats()
        {
            return Ok("Hello World");
        }

        // TODO: Update bot endpoint
        [HttpPut("Update")]
        IActionResult UpdateBot()
        {
            return Ok("Hello World");
        }

        // TODO: Delete bot endpoint
        [HttpDelete("Remove")]
        IActionResult DeleteBot()
        {
            return Ok("Hello World");
        }
    }
}
