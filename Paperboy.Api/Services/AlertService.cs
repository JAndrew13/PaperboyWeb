using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Paperboy.Api.Dtos;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Services

{
    public class AlertService
    {
        //private readonly AppDbContext _db;
        private readonly OrderService _orderService;
        private BotService _botService;
        private AppDbContext _db;

        public AlertService(
            AppDbContext db, 
            OrderService orderService,
            BotService botService)
        {
            _db = db;
            _orderService = orderService;
            _botService = botService;
            
        }

        public Alert CreateAlert(AlertDto alert)
        {
            Alert _alert = new Alert
            {
                Action = alert.Action,
                Ticker1 = alert.Ticker1,
                Ticker2 = alert.Ticker2,
                Id = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                BotId = (Guid)alert.BotId!
            };
            return _alert;
        }

        public async Task<Order> ProcessAlert(Alert _alert)
        {
            // get bot by id
            Bot _bot = await _botService.GetBotById(_alert.BotId);
            _alert.Bot = _bot;

            await _db.Alerts.AddAsync(_alert);
            await _db.SaveChangesAsync();

            // create order from alert
            Order order = _orderService.CreateNewOrder(_alert);
            order = await _orderService.PlaceMarketOrder(order);

            return order;

            //_db.Alerts.Add(_alert);
            //_db.SaveChanges();
        }

       
    }
}
