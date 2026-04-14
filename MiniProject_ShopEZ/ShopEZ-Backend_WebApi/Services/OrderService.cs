using ShopEZ.API.DTOs;
using ShopEZ.API.Models;
using ShopEZ.API.Repositories;

namespace ShopEZ.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderDto dto)
        {
            var order = new Order
            {
                UserId = dto.UserId
            };

            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                if (product == null)
                    throw new Exception("Product not found");

                if (product.Stock < item.Quantity)
                    throw new Exception("Insufficient stock");

                product.Stock -= item.Quantity;

                total += product.Price * item.Quantity;

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            order.TotalAmount = total;

            var savedOrder = await _orderRepo.AddAsync(order);

            return new OrderResponseDto
            {
                OrderId = savedOrder.OrderId,
                UserId = savedOrder.UserId,
                OrderDate = savedOrder.OrderDate,
                TotalAmount = savedOrder.TotalAmount
            };
        }

        public async Task<bool> DeleteOrderAsync(int id, int loggedInUserId, string role)
        {
            var order = await _orderRepo.GetByIdAsync(id);

            if (order == null)
                return false;

            // user can delete only own order

            if (role != "Admin" && order.UserId != loggedInUserId) // if not admin and not owner of the order cannot delete
                return false;

            foreach (var item in order.OrderItems)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                if (product != null)
                {
                    product.Stock += item.Quantity;
                }
            }

            return await _orderRepo.DeleteAsync(order);
        }
    }
}