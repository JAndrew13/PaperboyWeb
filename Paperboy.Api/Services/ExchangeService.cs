using Kucoin.Net.Clients;
using Kucoin.Net.Enums;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects;
using Microsoft.Extensions.Options;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;



namespace Paperboy.Api.Services;


public class ExchangeService
{
    private readonly IKucoinClient _client;

    // TODO: Add API Credentials to config
    public ExchangeService(IOptions<Secrets> options)
    {

        _client = new KucoinClient(
            new KucoinClientOptions() 
            {
            ApiCredentials = new KucoinApiCredentials(
                options.Value.Key,
                options.Value.Secret,
                options.Value.Passphrase
                ),
            });
    }

    public async Task<object> GetTokensPriceList()
    {
        var tickerData = await _client.SpotApi.ExchangeData.GetFiatPricesAsync();
        return tickerData;
    }

    public async Task<decimal> GetPrice(string pair) // ex. "BTC-USDT"
    {
        var allTickers = await _client.SpotApi.ExchangeData.GetTickersAsync();
        var pairData = allTickers.Data.Data.FirstOrDefault(x => x.SymbolName == pair);
        if (pairData != null) 
        {
            return pairData!.LastPrice.HasValue ? pairData.LastPrice.Value : 0;
        }
        else
        {
            return 0;
        }
        
    }

    public async Task<object> GetAccountSummary()
    {
        var accountData = await _client.SpotApi.Account.GetAccountsAsync();
        return accountData;
    }

    public async Task<decimal> GetTokenBalance(string token)
    {
        var accountData = await _client.SpotApi.Account.GetAccountsAsync();
        var tokensList = accountData.Data.ToList();
        for (int x = 0; x < tokensList.Count; x++)
        {
            if (tokensList[x].Asset == token &&
                tokensList[x].Type.ToString() == "Trade")
            {
                var accountType = tokensList[x].Type;
                return tokensList[x].Available;
            }
        }
        return 0;
    }

    public async Task<object> PlaceMarketBuyOrder(Order _order)
    {
        var orderData = await _client.SpotApi.Trading.PlaceOrderAsync(
            symbol: _order.Pair,
            OrderSide.Buy,
            NewOrderType.Market,
            quantity: _order.Amount,
            timeInForce: TimeInForce.GoodTillCanceled);

        _order.Status = orderData.Success ? "open" : orderData.Error!.Message;
        _order.TimeStamp = DateTime.Now;

        if (_order.Status == "open") 
        {
            _order.TxId = orderData.Data.Id;
        } else
        {
            _order.TxId = "error";
        }

        return _order;

    }

    public async Task<object> PlaceMarketSellOrder(Order _order)
    {
        var orderData = await _client.SpotApi.Trading.PlaceOrderAsync(
            symbol:_order.Pair,
            OrderSide.Sell,
            NewOrderType.Market,
            quantity: _order.Amount,
            timeInForce: TimeInForce.GoodTillCanceled);

        _order.Status = orderData.Success ? "open" : orderData.Error!.Message;
        _order.TimeStamp = DateTime.Now;

        if (_order.Status == "open")
        {
            _order.TxId = orderData.Data.Id;
        }
        else
        {
            _order.TxId = "error";
        }

        return _order;
    }

    public async Task<object> PlaceMarketOverrideBuyOrder(string pair, decimal amount)
    {
        var orderData = await _client.SpotApi.Trading.PlaceOrderAsync(
            pair,
            OrderSide.Buy,
            NewOrderType.Market,
            quantity: amount,
            timeInForce: TimeInForce.GoodTillCanceled);
        
        return orderData.Data;
    }

    public async Task<object> PlaceMarketOverrideSellOrder(string pair, int amount)
    {
        var orderData = await _client.SpotApi.Trading.PlaceOrderAsync( // example
            "MATIC-USDT",
            OrderSide.Sell,
            NewOrderType.Market,
            quantity: amount,
            timeInForce: TimeInForce.GoodTillCanceled);

        return orderData;
    }

    public async Task<object> GetOrderById(string TxId)
    {
        var orderData = await _client.SpotApi.Trading.GetOrderAsync(TxId); // example
        return orderData;
    }

    public async Task<object> CancelOrderById()
    {
        var orderData = await _client.SpotApi.Trading.CancelOrderAsync("1234"); // example
        return orderData;
    }
    
    public async Task<object> GetUserTrades()
    {
        var userTrades = await _client.SpotApi.Trading.GetUserTradesAsync("MATIC-USDC"); //example
        return userTrades;
    }


}
