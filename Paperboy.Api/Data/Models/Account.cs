using Paperboy.Api.Dtos;

namespace Paperboy.Api.Data.Models;

public class Account
{
    public string? AccountId { get; set; } = null!;
    public string? AccountType { get; set; } = null!;
    public decimal? AccountBalance { get; set; } = null!;

    public Dictionary<string, Token> AccountTokens { get; set; }
        = new Dictionary<string, Token>();
}

