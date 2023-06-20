namespace Paperboy.Api.Data.Models;

public class Order
{
    public Guid Id { get; set; }
    public string TxId { get; set; } = "";
    public string OrderType { get; set; } = "";
    public string Token1 { get; set; } = "MATIC";
    public string Token2 { get; set; } = "USDC";
    public string Pair { get; set; } = "";
    public string Status { get; set; } = "PENDING";
    public decimal TokenAmount { get; set; } = 0;
    public decimal AtPrice { get; set; } = 0;
    public decimal TotalValue{get ; set; } = 0;
    public DateTime TimeStamp { get; set; }

    public Alert? Alert { get; set; }
    public Guid AlertId { get; set; }
    public Bot? Bot { get; set; }
    public Guid BotId { get; set; }
}
