using ShopEZ.API.DTOs;

namespace ShopEZ.API.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(OrderDto dto);
        Task<bool> DeleteOrderAsync(int id, int loggedInUserId, string role);
    }
}