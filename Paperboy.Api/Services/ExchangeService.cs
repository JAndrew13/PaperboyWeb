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
        return accountData.Data; 
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
            quantity: _order.TokenAmount,
            timeInForce: TimeInForce.GoodTillCanceled);

        _order.Status = orderData.Success ? "OPEN" : orderData.Error!.Message;
        _order.TimeStamp = DateTime.Now;

        if (_order.Status == "OPEN") 
        {
            _order.TxId = orderData.Data.Id;
        } else
        {
            _order.TxId = "ERROR";
        }

        return _order;

    }

    public async Task<object> PlaceMarketSellOrder(Order _order)
    {
        var orderData = await _client.SpotApi.Trading.PlaceOrderAsync(
            symbol:_order.Pair,
            OrderSide.Sell,
            NewOrderType.Market,
            quantity: _order.TokenAmount,
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

    public async Task<object> GetOrderUpdateById(string TxId)
    {
        var orderData = await _client.SpotApi.Trading.GetOrderAsync(TxId); // example
        return orderData;
    }

    public async Task<object> CancelOrderById(string TxId)
    {
        var orderData = await _client.SpotApi.Trading.CancelOrderAsync(TxId); // example
        return orderData;
    }

    public async Task<object> GetUserTrades(string pair)
    {
        var userTrades = await _client.SpotApi.Trading.GetUserTradesAsync(pair); //example
        return userTrades;
    }

    public async Task<object> GetQuickPrice(string pair)
    {
        var singleTokenPrice = await _client.SpotApi.CommonSpotClient.GetTickerAsync(pair);
        return singleTokenPrice.Data;
    }


}
