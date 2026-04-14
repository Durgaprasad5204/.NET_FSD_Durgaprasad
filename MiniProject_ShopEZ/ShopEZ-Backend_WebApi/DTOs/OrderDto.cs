namespace ShopEZ.API.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public List<OrderItemRequestDto> Items { get; set; } = new();
    }

    public class OrderItemRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}