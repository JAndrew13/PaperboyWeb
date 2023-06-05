namespace Paperboy.Api.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderId { get; set; } = "";
        public string OrderType { get; set; } = ""; // buy or sell (token1 for token2)
        public string Token1 { get; set; } = "MATIC"; // default to MATIC
        public string Token2 { get; set; } = "USDC"; // default to USDC
        public string Pair { get; set; } = ""; // "token1-token2"
        public string BotId { get; set; } = "";
        public string Status { get; set; } = "PENDING"; // default to pending (ENUM: pending, open, filled, cancelled)
        public decimal Amount { get; set; } = 0; // default to 0
        public DateTime TimeStamp { get; set; }
    }
}
