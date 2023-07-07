using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Services;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Dtos;

namespace Paperboy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BotController : ControllerBase
{
    private readonly BotService _botService;

    public BotController(BotService botService)
    {
        _botService = botService;
    }

    [HttpPost("Create")]
    public IActionResult CreateBot(object? botData)
    {
        Bot _bot = _botService.CreateNewBot();
        return Ok(_bot);
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateBot(BotDto botDto)
    {
        await _botService.UpdateBot(botDto);
        
        return Ok("Success: Bot Updated");
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> RemoveBot(Guid botId)
    {
        bool response = await _botService.RemoveBot(botId);
        if (response)
        {
            return Ok("Success! Bot (" + botId + ") has been removed");
        }
        else
        {
            return BadRequest("Error! Bot (" + botId + ") could not be removed");
        }

 

    }
}

