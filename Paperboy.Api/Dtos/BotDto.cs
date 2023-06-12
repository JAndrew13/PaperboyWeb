using Paperboy.Api.Services;

namespace Paperboy.Api.Dtos;

public class BotDto
{
    public required String Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public string? Exchange { get; set; } = null!;
    public string? TradingPair { get; set; } = null!;
    public DateTime? CreatedDate { get; set; } = null;
    public double? StartingBalance { get; set; } = null!;
    public int? TotalTrades { get; set; } = null!;

    public Dictionary<string, OrderDto> Orders { get; set; } = new Dictionary<string, OrderDto>();
}
