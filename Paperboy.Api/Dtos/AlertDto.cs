namespace Paperboy.Api.Dtos;

public class AlertDto
{
    public string Action { get; set; } = null!; 
    public string Ticker1 { get; set; } = "MATIC"; 
    public string Ticker2 { get; set; } = "USDC"; 
    public Guid? BotId { get; set; } = null!;
}
