using OrderKaBA.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderKaBA.DTOs
{
    public class OrderCreateDto
    {
        [Required]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderItemCreateDto> OrderItems { get; set; } = new();
    }

    public class OrderItemCreateDto
    {
        public int DishId { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
