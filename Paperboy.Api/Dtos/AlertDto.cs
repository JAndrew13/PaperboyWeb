namespace Paperboy.Api.Dtos
{
    public class AlertDto
    {
        public string Action { get; set; } = null!; // buy or sell
        public string Ticker1 { get; set; } = "MATIC"; // default to MATIC
        public string Ticker2 { get; set; } = "USDC"; // default to USDC
        public string BotName { get; set; } = null!;
        public DateTime timeStamp { get; set; }
    }
}
