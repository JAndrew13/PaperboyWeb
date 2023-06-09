using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("Balance")]
        public IActionResult Get()
        {
            // TODO: Fetch Account Balance from Exchange using Account Service
            return Ok("Hello World");
        }

        [HttpGet("Tokens")]
        public IActionResult GetTokens()
        {
            // TODO: Fetch Account Tokens from Exchange using Account Service
            return Ok("Hello World");
        }

        [HttpGet("Price")]
        public IActionResult GetPrice()
        {
            // TODO: Fetch Price of Token from Exchange using Account Service
            return Ok("Hello World");
        }
    }
}
