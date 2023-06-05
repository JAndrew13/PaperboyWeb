
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Services;
//using Paperboy.Api.Dtos;
using Paperboy.Api.Data.Models;

namespace Paperboy.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly AlertService _alertService;
        private readonly OrderService _orderService;

        public AlertsController(AlertService alertService, OrderService orderService)
        {
            _alertService = alertService;
            _orderService = orderService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAlert(Alert alert)
        {
            // Create new alert object using alert service
            var alertObj = await _alertService.CreateAlert(alert);
            return (Ok(alertObj));

        }

        [HttpPost("Buy x Matic")]
        public async Task<IActionResult> BuyMatic()
        {
            var _exchangeService = new ExchangeService();
            string pair = "MATIC-USDT";
            int amount = 84;
            var tokenBalance = await _exchangeService.PlaceMarketOverrideBuyOrder(pair, amount);
            return (Ok(tokenBalance));
        }

        [HttpPost("Sell x Matic")]
        public async Task<IActionResult> SellMatic()
        {
            var _exchangeService = new ExchangeService();
            string pair = "MATIC-USDT";
            int amount = 1;
            var tokenBalance = await _exchangeService.PlaceMarketOverrideSellOrder(pair, amount);
            return (Ok(tokenBalance));
        }

    }
}
