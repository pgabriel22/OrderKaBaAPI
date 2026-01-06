namespace OrderKaBA.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
