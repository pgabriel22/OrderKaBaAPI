namespace OrderKaBA.DTOs
{
    public class DishReadDto
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DishType { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
    }
}
