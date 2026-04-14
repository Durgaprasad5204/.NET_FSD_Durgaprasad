using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEZ.API.DTOs;
using ShopEZ.API.Services;

namespace ShopEZ.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            return Ok(await _service.CreateOrderAsync(dto));
        }



        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var roleClaim = User.FindFirst(ClaimTypes.Role);

            if (userIdClaim == null || roleClaim == null)
                return Unauthorized("Invalid token");

            var loggedInUserId = int.Parse(userIdClaim.Value);
            var role = roleClaim.Value;

            var deleted = await _service.DeleteOrderAsync(id, loggedInUserId, role);

            if (!deleted)
                return NotFound("Order not found");

            return Ok("Order deleted successfully");
        
    }
    }
}