namespace Paperboy.Api.Dtos;
public class OrderDto
{
    public string BotId { get; set; } = null!;
    public string AlertId { get; set; } = null!;
    public string? Id { get; set; } = null!;
    public string? TxId { get; set; } = null!;
    public string? OrderType { get; set; } = null!;
    public string? Token1 { get; set; } = null!;
    public string? Token2 { get; set; } = null!;
    public string? Pair { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public decimal? TokenAmount { get; set; } = null!;
    public decimal? AtPrice { get; set; } = null!;
    public decimal? TotalValue { get; set; } = null!;
    public DateTime? TimeStamp { get; set; } = null!;
}