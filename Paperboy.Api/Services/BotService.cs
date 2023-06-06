using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;
using Microsoft.Identity.Client;

namespace Paperboy.Api.Services

{
    public class BotService
    {
        private AppDbContext _db;

        public BotService(AppDbContext db)
        {
            _db = db;

            // TODO: Create Bot Object
            Bot CreateNewBot()
            {
                Bot _newBot = new()
                {
                    Id = Guid.NewGuid()
                };

                return _newBot;
            }
        }
        // TODO: Get Bot Object by Id in db
        // Create method that searche for bot by id in the database and returns bot object
        public async Task<Bot> GetBotById(Guid id)
        {
            Bot? _bot = await _db.Bots.FindAsync(id);
            return _bot!;
        }
            

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
    }
}

