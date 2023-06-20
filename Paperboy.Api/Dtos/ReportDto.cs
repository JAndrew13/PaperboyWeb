namespace Paperboy.Api.Dtos;
public class ReportDto
{
    public Dictionary<string, BotDto> Bots { get; set; }
        = new Dictionary<string, BotDto>();
}
