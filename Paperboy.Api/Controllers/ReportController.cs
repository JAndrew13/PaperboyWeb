using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Services;

namespace Paperboy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("BotReport")]
    public async Task<ActionResult> GenerateReportDto(Guid? botId)
    {
        var botReport = await _reportService.GenerateReportDto(botId);
        return Ok(botReport);
    }
}
