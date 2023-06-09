using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("Accounts")]
        public IActionResult Get()
        {
            // TODO: Fetch Account Balance from Exchange using Account Service
            // Return A list of accounts and their balances of each token
            return Ok("Hello World");
        }

        [HttpGet("AccountTokens")]
        public IActionResult GetTokens()
        {
            // TODO: Fetch Account Tokens from Exchange using Account Service
            // Return A list tokens for a specific account
            return Ok("Hello World");
        }
    }
}
