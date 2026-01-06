using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrderKaBA.DTOs
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderReadItemDto> OrderItems { get; set; } = new();
    }
    public class OrderReadItemDto
    {
        public int DishId { get; set; }
        [Required]
        public string DishName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [JsonPropertyName("totalPrice")]
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
