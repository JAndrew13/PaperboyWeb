namespace Paperboy.Api.Dtos;
public class ReportDto
{
    public decimal AccountBalance { get; set; }
    public Dictionary<string, BotDto> Bots { get; set; } 
        = new Dictionary<string, BotDto>();
    public Dictionary<string, TokenAccountInfo> AccountTokens { get; set; } 
        = new Dictionary<string, TokenAccountInfo>();
}
public class TokenAccountInfo
{
    public decimal AmountOwned { get; set; }
    public decimal PriceInUsd { get; set; }
    public decimal BalanceInUsd { get; set; }
}