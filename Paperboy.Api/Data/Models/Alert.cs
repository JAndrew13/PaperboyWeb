namespace Paperboy.Api.Data.Models
{

    public class Alert
    {
        // these values should match the data being sent from the webhooks
        public Guid Id { get; set; }
        public required string Action { get; set; } = "BUY"; // buy or sell
        public required string Ticker1 { get; set; } = "MATIC"; // default to MATIC
        public required string Ticker2 { get; set; } = "USDC"; // default to USDC    
        public DateTime? TimeStamp { get; set; }

        public Order? Order { get; set; }
        public Bot? Bot { get; set; }
        public Guid BotId { get; set; } // Don't forget the bot
    }
}
