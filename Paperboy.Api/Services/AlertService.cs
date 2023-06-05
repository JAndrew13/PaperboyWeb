using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Services

{
    public class AlertService
    {
        //private readonly AppDbContext _db;
        private readonly OrderService _orderService;

        public AlertService(AppDbContext db, OrderService orderService)
        {
            //_db = db;
            _orderService = orderService;
        }

        public async Task<Order> CreateAlert(Alert alert)
        {
            Alert _alert = new Alert
            {
                Action = alert.Action,
                Ticker1 = alert.Ticker1,
                Ticker2 = alert.Ticker2,
                BotId = alert.BotId,
                timeStamp = DateTime.Now
            };

            Order order = _orderService.CreateNewOrder(_alert);
            order = await _orderService.PlaceMarketOrder(order);

            return order;

            //_db.Alerts.Add(_alert);
            //_db.SaveChanges();
        }

        // TODO: Pass Alert object to Order Service
    }
}
