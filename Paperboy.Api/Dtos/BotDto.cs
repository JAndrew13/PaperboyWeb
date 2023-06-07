using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Dtos;

public class BotDto
{
    public required String Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public string? Exchange { get; set; } = null!;
    public string? TradingPair { get; set; } = null!;
    public double? StartingBalance { get; set; } = null!;
    public double? CurrentBalance { get; set; } = null!;
    public double? ProfitLoss { get; set; } = null!;
    public double? ProfitLossPercent { get; set; } = null!;
    public int? TotalTrades { get; set; } = null!;
}
