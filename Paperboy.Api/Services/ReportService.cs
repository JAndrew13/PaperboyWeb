﻿using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Paperboy.Api.Services;

public class ReportService
{
    private AppDbContext _db;
    //private ExchangeService _exchangeService;
    private OrderService _orderService;
    private BotService _botService;

    public ReportService(
        AppDbContext db,
        //ExchangeService exchangeService,
        OrderService orderService,
        BotService botService)
    {
        _db = db;
        //_exchangeService = exchangeService;
        _orderService = orderService;
        _botService = botService;
    }
    public async Task<ReportDto> GenerateReportDto(Guid? botId = null)
    {
        ReportDto report = new ReportDto();

        // Get the list of bots, filtered by BotId if provided.
        List<Bot> bots;

        if (botId != null)
        {
            bots = await _db.Bots
                .Where(bot => bot.Id == botId.Value)
                .Include(bot => bot.Orders)
                .ToListAsync();
        }
        else
        {
            bots = await _db.Bots
                .Include(bot => bot.Orders)
                .ToListAsync();
        }

        foreach (var bot in bots)
        {
            BotDto botDto = _botService.CreateBotDto(bot);

            foreach (var order in bot.Orders)
            {
                OrderDto orderDto = _orderService.CreateOrderDto(order);
                botDto.Orders.Add(orderDto.Id.ToString(), orderDto);
            }
            report.Bots.Add(botDto.Id, botDto);
        }
        return report;
    }

    // TODO: Create logic for fetching token data
    // TODO: Creata logic for fetching account data from the exchange
}
