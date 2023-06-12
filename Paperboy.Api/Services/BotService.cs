using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Dtos;
using System.Data.Entity;

namespace Paperboy.Api.Services;

public class BotService
{
    private readonly AppDbContext _db;
    public BotService(AppDbContext db)
    {
        _db = db;
    }
    
    public Bot CreateNewBot()
    {
        Bot _newBot = new()
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
        };

        _db.Bots.Add(_newBot);
        _db.SaveChanges();

        return _newBot;
    }
    
    public async Task<Bot> GetBotById(Guid Id)
    {
        Bot? _bot = await _db.Bots.FindAsync(Id);
        return _bot!;
    }

    // Create new botDto from bot
    public BotDto CreateBotDto(Bot bot)
    {
        BotDto _botDto = new()
        {

            Id = bot.Id.ToString(),
            Name = bot.Name,
            Description = bot.Description,
            Status = bot.Status,
            Exchange = bot.Exchange,
            TradingPair = bot.TradingPair,
            StartingBalance = bot.StartingBalance,
            TotalTrades = bot.TotalTrades,
            CreatedDate = bot.CreatedDate
        };

        return _botDto;
    }

    public async Task<Bot> UpdateBot(BotDto botDto)
    {
        if (botDto.Id == null)
        {
            throw new Exception("No bot Id provided");
        }
        Guid botId = Guid.Parse(botDto.Id);
        Bot? bot = await _db.Bots.FindAsync(botId) ?? throw new Exception("No bot found with the provided Id");
        bot.Name = botDto.Name ?? bot.Name;
        bot.Description = botDto.Description ?? bot.Description;
        bot.Status = botDto.Status ?? bot.Status;
        bot.Exchange = botDto.Exchange ?? bot.Exchange;
        bot.TradingPair = botDto.TradingPair ?? bot.TradingPair;
        bot.StartingBalance = botDto.StartingBalance ?? bot.StartingBalance;
        bot.TotalTrades = botDto.TotalTrades ?? bot.TotalTrades;

        await _db.SaveChangesAsync();

        return bot;
    }

    public async Task<bool> RemoveBot(Guid botId)
    {
        Bot? _bot = await GetBotById(botId);
        _db.Bots.Remove(_bot!);
        await _db.SaveChangesAsync();
        return true;
    }

    // ============================================ // 
}

