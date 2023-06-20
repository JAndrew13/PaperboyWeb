using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Services;

public class AccountService
{
    private readonly ExchangeService _exchangeService;

    public AccountService(ExchangeService exchangeService)
    {
        _exchangeService = exchangeService;
    }

    public async Task<object> ParseAccountSummary()
    {
        var response = await _exchangeService.GetAccountSummary();
        return response;
    }

    public async Task<object> GetExchangeData(string pair)
    {
        var exchangeData = await _exchangeService.GetQuickPrice("MATIC-USDT");
        return exchangeData;
    }
}
