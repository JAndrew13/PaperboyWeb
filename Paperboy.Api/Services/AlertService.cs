using Paperboy.Api.Dtos;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Services;


public class AlertService
{
    private readonly OrderService _orderService;
    private readonly BotService _botService;
    private readonly AppDbContext _db;

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
        Alert _alert = new()
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

        // save alert to db
        await _db.Alerts.AddAsync(_alert);
        await _db.SaveChangesAsync();

        // create order from alert
        Order order = _orderService.CreateNewOrder(_alert);

        // save order to db
        await _db.Orders.AddAsync(order);   
        await _db.SaveChangesAsync();

        order = await _orderService.PlaceMarketOrder(order);

        
        OrderDto orderDto= new()
        {
            Id = order.Id.ToString(),
            TxId = order.TxId,
            OrderType = order.OrderType,
            Token1 = order.Token1,
            Token2 = order.Token2,
            Pair = order.Pair,
            Status = order.Status,
            TokenAmount = order.TokenAmount,
            TimeStamp = order.TimeStamp,
            TotalValue = order.TotalValue,
            AtPrice = order.AtPrice,
        };

        var updatedOrder = await _orderService.GetOrderUpdateUntilFilledOrLimit(orderDto);

        order.Status = updatedOrder.Status!;
        return order;
    }
}
