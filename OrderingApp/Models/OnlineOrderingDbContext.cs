using System.Data.Entity;

namespace OrderingApp.Models
{
    public class OnlineOrderingDbContext : DbContext
    {
        public OnlineOrderingDbContext() : base("OnlineOrderingConnection")
        {
                
        }
        
        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Order> Order { get; set; }

        public System.Data.Entity.DbSet<OrderingApp.Models.CategoryVM> CategoryVMs { get; set; }
    }
}