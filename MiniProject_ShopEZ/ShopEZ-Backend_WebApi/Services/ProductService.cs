using ShopEZ.API.DTOs;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories;

namespace ShopEZ.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
           return await _repo.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Product> AddAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock
            };
            return await _repo.AddAsync(product);
        }

        public async Task<Product?> UpdateAsync(int id, ProductDto dto)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.Stock = dto.Stock;

            return await _repo.UpdateAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}