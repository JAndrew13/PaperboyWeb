using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Dtos;
// TODO: Add Patch endpoint to BotController that updates order details from DTO
// TODO: Add Method to OrderService to update order details from DTO
public class OrderDto
{
    public string? Id { get; set; } = null!;
    public string? TxId { get; set; } = null!;
    public string? OrderType { get; set; } = null!;
    public string? Token1 { get; set; } = null!;
    public string? Token2 { get; set; } = null!;
    public string? Pair { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public decimal? Amount { get; set; } = null!;
    public DateTime? TimeStamp { get; set; } = null!;
}