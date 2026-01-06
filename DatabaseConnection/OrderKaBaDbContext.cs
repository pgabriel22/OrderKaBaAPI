using Microsoft.EntityFrameworkCore;
using OrderKaBA.Models;

namespace OrderKaBA.DatabaseConnection
{
    public class OrderKaBaDbContext : DbContext
    {
        public OrderKaBaDbContext(DbContextOptions<OrderKaBaDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Dish> Dishes { get; set; } 
    }
}
