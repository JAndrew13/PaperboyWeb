using Microsoft.EntityFrameworkCore;
using System.Data;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Dtos;


// TODO: Update Bot Object in Database
// TODO: Remove Bot Object
// TODO: Get Bot Stats
// TODO: Calculate Bot Stats
// TODO: Calculate Bot ROI
// TODO: Calculate Bot Profit
// TODO: Calculate Bot Los
// TODO: Get Bot Orders
// TODO: Get Bot Alerts
// TODO: Get Bot Trades

namespace Paperboy.Api.Services

{
    public class BotService
    {
        private AppDbContext _db;

        public BotService(AppDbContext db)
        {
            _db = db;
        }
        
        public Bot CreateNewBot()
        {
            Bot _newBot = new()
            {
                Id = Guid.NewGuid()
            };

            _db.Bots.Add(_newBot);
            _db.SaveChanges();

            return _newBot;
        }
        
        public async Task<Bot> GetBotById(Guid Id)
        {
            Bot? _bot = await _db.Bots.FindAsync(Id);
            // TODO: Add error handling, what if the bot is not found?
            return _bot!;
        }

        // TODO: Update Bot Object in Database
        public async Task<Bot> UpdateBot(BotDto botDto)
        {
            if (botDto.Id == null)
            {
                throw new Exception("No bot Id provided");
            }
            Guid botId = Guid.Parse(botDto.Id);
            Bot bot = await _db.Bots.FindAsync(botId);
            if (bot == null)
            {
                throw new Exception("No bot found with the provided Id");
            }

            bot.Name = botDto.Name ?? bot.Name;
            bot.Description = botDto.Description ?? bot.Description;
            bot.Status = botDto.Status ?? bot.Status;
            bot.Exchange = botDto.Exchange ?? bot.Exchange;
            bot.TradingPair = botDto.TradingPair ?? bot.TradingPair;
            bot.StartingBalance = botDto.StartingBalance ?? bot.StartingBalance;
            bot.CurrentBalance = botDto.CurrentBalance ?? bot.CurrentBalance;
            bot.ProfitLoss = botDto.ProfitLoss ?? bot.ProfitLoss;
            bot.ProfitLossPercent = botDto.ProfitLossPercent ?? bot.ProfitLossPercent;
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
        
        public async Task<Order[]> GetBotOrders(Guid botId)
        {
            Order[] orders = await _db.Orders.Where(o => o.BotId == botId).ToArrayAsync();
            return orders;
        }

        public async Task<Alert[]> GetBotAlerts(Guid botId)
        {
            Alert[] _alerts = await _db.Alerts.Where(a => a.BotId == botId).ToArrayAsync();
            return _alerts;
        }
        
    }
}

