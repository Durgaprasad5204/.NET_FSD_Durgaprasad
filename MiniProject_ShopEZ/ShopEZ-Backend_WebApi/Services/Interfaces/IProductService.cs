using ShopEZ.API.DTOs;
using ShopEZ.API.Models;

namespace ShopEZ.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(ProductDto dto);
        Task<Product?> UpdateAsync(int id, ProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}