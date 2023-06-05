using System;

namespace Paperboy.Api.Data.Models
{
    public class Alert
    {
        // these values should match the data being sent from the webhooks
        public int Id { get; set; }
        public string Action { get; set; } = "BUY"; // buy or sell
        public string Ticker1 { get; set; } = "MATIC"; // default to MATIC
        public string Ticker2 { get; set; } = "USDC"; // default to USDC
        public string BotId { get; set; } = null!;
        public DateTime timeStamp { get; set; }
    }
}
