using System.ComponentModel.DataAnnotations;

namespace OrderKaBA.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string DishName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DishType { get; set; }   
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
