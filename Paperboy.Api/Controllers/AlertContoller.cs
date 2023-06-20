
using Microsoft.AspNetCore.Mvc;
using Paperboy.Api.Services;
using Paperboy.Api.Dtos;
using Paperboy.Api.Data.Models;

namespace Paperboy.api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<IActionResult> CreateAlert([FromBody] AlertDto alertDto)
    {
        // Create new alert object using alert service
        var alertObj = _alertService.CreateAlert(alertDto);

        // Process alert object using alert service
        await _alertService.ProcessAlert(alertObj);
        return Ok();
    }

    [HttpGet("OrderStatus")] // get order status by id
    public async Task<IActionResult> GetOrderUpdateById(OrderDto orderDto)
    {
        // validate order input
        if (orderDto.TxId == null || orderDto.Id == null)
        {
            return BadRequest("Error: TxId required");
        }

        var updatedOrder = await _orderService.GetOrderUpdateUntilFilledOrLimit(orderDto);
        // get order status from exchange
       
        if (updatedOrder == null)
        {
            return BadRequest("Error: Order not found on Exchange");
        }

        return Ok(updatedOrder);
    }

}
