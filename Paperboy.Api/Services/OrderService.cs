using Paperboy.Api.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Paperboy.Api.Data.Models;
using Kucoin.Net.Enums;

// TODO: Get Order Status
// TODO: Get Order Hitory
// TODO: Cancel Order
// TODO: Get Order Stats
// TODO: Calculate Order ROI
// TODO: Calculate Order Profit
// TODO: Calculate Order Loss

namespace Paperboy.Api.Services
{
    public class OrderService
    {
        private AppDbContext _db;
        private readonly ExchangeService _exchangeService;

        public OrderService(AppDbContext db)
        {
            _db = db;
            _exchangeService = new ExchangeService();
        }

        public Order CreateNewOrder(Alert alert)
        {
            Order _order = new Order
            {
                Id = Guid.NewGuid(),
                OrderType = alert.Action,
                Token1 = alert.Ticker1,
                Token2 = alert.Ticker2,
                Pair = alert.Ticker1 + "-" + alert.Ticker2,
                Bot = alert.Bot!,
                BotId = alert.BotId,
                Alert = alert,
                AlertId = alert.Id,
            };

            return _order;
        }

        public async Task<Order>PlaceMarketOrder(Order _order)
        {
            var _exchangeService = new ExchangeService();

            if (await ValidateOrder(_order)) 
            {
                // Fetch wallet balances
                decimal token1Balance = await _exchangeService.GetTokenBalance(_order.Token1);
                decimal token2Balance = await _exchangeService.GetTokenBalance(_order.Token2);
                decimal token1Value = await _exchangeService.GetPrice(_order.Pair);

                // Determine amount to buy/sell depending on order type
                decimal orderQuantity = 0;

                if (_order.OrderType == "BUY")
                {
                    orderQuantity = token2Balance / token1Value - 3;
                    var orderQuantityRounded = Math.Round(orderQuantity, 1);    
                    _order.Amount = orderQuantityRounded ;
                    var orderResult = await _exchangeService.PlaceMarketBuyOrder(_order);

                    // update order in database
                    _db.Orders.Update(_order);
                    await _db.SaveChangesAsync();
                }
                
                else if (_order.OrderType == "SELL")
                {
                    var orderQuantityRounded = Math.Round(token1Balance, 1);
                    _order.Amount = orderQuantityRounded - 1;
                    var orderResult = await _exchangeService.PlaceMarketSellOrder(_order);

                    // update order in database
                    _db.Orders.Update(_order);
                    await _db.SaveChangesAsync();
                }


                return _order;
            }
            // TODO: Handle failed order
            return _order; // order failed to place
        }

        public async Task<bool> ValidateOrder(Order _order) 
        {
            var _exchangeService = new ExchangeService();

            // TODO: Check Account has enough funds?

            // Check Pair exists
            decimal currentPrice = await _exchangeService.GetPrice(_order.Pair);
            if (currentPrice == 0)
            {
                return false; // Pair doesnt exist
            }

            // TODO: Check botId exists in db
            // TODO: Check botId is active

            return true;
        }

        // TODO: Get Order Status
        // TODO: Get Order Hitory
        // TODO: Cancel Order
        // TODO: Get Order Stats
        // TODO: Calculate Order ROI
        // TODO: Calculate Order Profit
        // TODO: Calculate Order Loss
    }
}
