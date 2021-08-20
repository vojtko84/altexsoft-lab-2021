using DeliveryEF.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryEF.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<DeliveryRate> DeliveryRates { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-4CRRHI0;Initial Catalog=DeliveryEF;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasMany(o => o.Products).WithMany(p => p.Orders);
        }
    }
}