using ShopEZ.API.Models;

namespace ShopEZ.API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<Order?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(Order order);
    }
}