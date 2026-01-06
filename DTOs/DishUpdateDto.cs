using System.ComponentModel.DataAnnotations;

namespace OrderKaBA.DTOs
{
    public class DishUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string DishName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }
        [Required]
        public int DishType { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
    }
}
