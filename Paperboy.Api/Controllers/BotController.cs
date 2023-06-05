using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paperboy.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        public BotController() 
        {
            // TODO: Add Bot Service
            // TODO: Add Bot Model
            // TODO: Add Bot DTO

            // Create bot endpoint
            [HttpPost("Create")]
            IActionResult CreateBot()
            {
                return Ok("Hello World");
            }

            // Get bot Stats endpoint
            [HttpGet("Report")]
            IActionResult GetBotStats()
            {
                return Ok("Hello World");
            }

            // Update bot endpoint
            [HttpPut("Update")]
            IActionResult UpdateBot()
            {
                return Ok("Hello World");
            }

            // Delete bot endpoint
            [HttpDelete("Remove")]
            IActionResult DeleteBot()
            {
                return Ok("Hello World");
            }

        }
    }
}
