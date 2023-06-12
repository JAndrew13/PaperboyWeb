using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Services;

namespace Paperboy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            
            _accountService = accountService;
        }

        // TODO: Add optional Inupt
        [HttpGet("Accounts")]
        public async Task<IActionResult> GetAccountsSummary()
        {
            var accountData = await _accountService.ParseAccountSummary();
            return Ok(accountData);
        }

        [HttpGet("GetTokenPrice")]
        public async Task<IActionResult> GetExchangeData(string pair)
        {
            var exchangeData = await _accountService.GetExchangeData(pair);
            return Ok(exchangeData);
        }   
    }
}
