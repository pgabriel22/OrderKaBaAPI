namespace OrderKaBA.DTOs
{
    public class OrderUpdateDto
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderItemUpdateDto> OrderItems { get; set; } = new();
    }
    public class OrderItemUpdateDto
    {
        public int? OrderItemId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}
