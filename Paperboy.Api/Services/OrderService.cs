
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Dtos;


namespace Paperboy.Api.Services;

public class OrderService
{
    private readonly AppDbContext _db;
    private readonly ExchangeService _exchangeService;

    public OrderService(AppDbContext db, ExchangeService exchangeService)
    {
        _db = db;
        _exchangeService = exchangeService;
    }

    public Order CreateNewOrder(Alert alert)
    {
        Order _order = new()
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

    public OrderDto CreateOrderDto(Order order)
    {
        OrderDto orderDto = new()
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
            AlertId = order.AlertId.ToString(),
            BotId = order.BotId.ToString(),
            AtPrice = order.AtPrice,
            TotalValue = order.TotalValue,
        };

        return orderDto;
    }

    public async Task<Order> PlaceMarketOrder(Order _order)
    {

        if (await ValidateOrder(_order))
        {
            // Fetch wallet balances
            decimal token1Balance = await _exchangeService.GetTokenBalance(_order.Token1);
            decimal token2Balance = await _exchangeService.GetTokenBalance(_order.Token2);
            decimal token1Value = await _exchangeService.GetPrice(_order.Pair);

            decimal orderQuantity = 0;

            // TODO: set _order's TokenValue and TotalValue properties
            // TODO: refactor this to use switch statement

            if (_order.OrderType == "BUY")
            {
                orderQuantity = token2Balance / token1Value - 3;
                var orderQuantityRounded = Math.Round(orderQuantity, 1);
                _order.TokenAmount = orderQuantityRounded;
                _order.AtPrice = token1Value;
                _order.TotalValue = _order.TokenAmount * _order.AtPrice;

                var orderResult = await _exchangeService.PlaceMarketBuyOrder(_order);

                _db.Orders.Update(_order);
                await _db.SaveChangesAsync();
            }

            else if (_order.OrderType == "SELL")
            {
                var orderQuantityRounded = Math.Round(token1Balance, 1);
                _order.TokenAmount = orderQuantityRounded - 1;
                _order.AtPrice = token1Value;
                _order.TotalValue = _order.TokenAmount * _order.AtPrice;
                var orderResult = await _exchangeService.PlaceMarketSellOrder(_order);


                _db.Orders.Update(_order);
                await _db.SaveChangesAsync();
            }


            return _order;// order placed
        }
        // TODO: Handle failed order

        return _order; // order failed to place
    }

    public async Task<bool> ValidateOrder(Order _order)
    {
        // TODO: Check Account has enough funds?
        // TODO: Check botId exists in db
        // TODO: Check botId is active

        decimal currentPrice = await _exchangeService.GetPrice(_order.Pair);
        if (currentPrice == 0)
        {
            return false; // Pair doesnt exist
        }

        return true; // Order details are valid
    }

    public async Task<OrderDto> GetOrderUpdateUntilFilledOrLimit(OrderDto orderDto)
    {
        int maxRetries = 20;
        int retries = 0;

        while (retries < maxRetries)
        {
            // Get order status from exchange
            dynamic response = await _exchangeService.GetOrderUpdateById(orderDto.TxId!);

            if (response != null)
            {
                decimal quantityFilled = response.Data.QuantityFilled;
                decimal quantity = response.Data.Quantity;

                if (quantityFilled == quantity)
                {
                    
                    // Order is filled, update status in db
                    return await UpdateOrderStatusInDb(orderDto, "FILLED");
                }
            }

            // Wait for 5 seconds before retrying
            await Task.Delay(TimeSpan.FromSeconds(5));
            retries++;
        }

        // If we reach here, max retries was hit without the order being filled
        return orderDto;
    }

    public async Task<OrderDto> UpdateOrderStatusInDb(OrderDto orderDto, string status)
    {
        // update the order in the database

        Guid orderId = Guid.Parse(orderDto.Id!);

        var order = await _db.Orders.FindAsync(orderId);

        

        if (order != null)
        {
            order.Status = status;

            await _db.SaveChangesAsync();

            // Map the updated order entity to an OrderDto and return

            // Map properties from order to orderDto
            orderDto.Status = order.Status;

            return orderDto;
        }

        return null!;
    }
}
