namespace Paperboy.Api.Data.Models;
public class Alert
{
    public Guid Id { get; set; }
    public required string Action { get; set; } = "BUY";
    public required string Ticker1 { get; set; } = "MATIC";
    public required string Ticker2 { get; set; } = "USDC";
    public DateTime? TimeStamp { get; set; }

    public Order? Order { get; set; }
    public Bot? Bot { get; set; }
    public Guid BotId { get; set; }
}
