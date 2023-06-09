namespace Paperboy.Api.Data.Models;

public class Bot
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "Paperboy";
    public string Description { get; set; } = "A Simple Trading Bot";
    public string Status { get; set; } = "Active";
    public string Exchange { get; set; } = "KuCoin";
    public string TradingPair { get; set; } = "MATIC-USDT";
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public double StartingBalance { get; set; } = 0;
    public int TotalTrades { get; set; } = 0;

    public ICollection<Alert> Alerts { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = null!;
}
