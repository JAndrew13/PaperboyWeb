
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Services;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Dtos;

namespace Paperboy.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BotController : ControllerBase
{
    private BotService _botService;

    public BotController(BotService botService)
    {
        _botService = botService;
    }

    [HttpPost("Create")]
    public IActionResult CreateBot()
    {
        Bot _bot = _botService.CreateNewBot();
        return Ok(_bot);
    }

    [HttpGet("Orders")]
    public async Task<IActionResult> GetBotOrders(Guid botId)
    {
        Order[] orders = await _botService.GetBotOrders(botId);
        return Ok(orders);
    }

    [HttpGet("Alerts")]
    public async Task<IActionResult> GetBotAlerts(Guid botId)
    {
        Alert[] alerts = await _botService.GetBotAlerts(botId);
        return Ok(alerts);
    }

    // TODO: Update bot endpoint
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

