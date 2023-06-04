using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UpStorage.Domain.Entities;

namespace UpStorage.Infrastructure.Contexts
{
    public class UpStorageDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderEvent> OrderEvents { get; set; }

        public UpStorageDbContext(DbContextOptions<UpStorageDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    } 
}