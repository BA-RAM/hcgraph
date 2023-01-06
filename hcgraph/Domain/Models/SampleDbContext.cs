using System;
using Microsoft.EntityFrameworkCore;

namespace hcgraph.Domain.Models
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Item> Items { get; set; }

        // Set schema and seed test data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.RowId);
                entity.Property(e => e.LastModified);
                entity.Property(e => e.OrderDate);
                entity.Property(e => e.OrderNumber).HasMaxLength(250);

                entity.HasData(new Order
                {
                    RowId = 1,
                    LastModified = DateTime.UtcNow,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "Order_1",
                }, new Order
                {
                    RowId = 2,
                    LastModified = DateTime.UtcNow,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "Order_2",
                });
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.RowId);
                entity.Property(e => e.LastModified);
                entity.Property(e => e.OrderId);
                entity.Property(e => e.ItemId);
                entity.Property(e => e.Quantity);

                entity.HasData(new OrderItem
                {
                    RowId = 1,
                    LastModified = DateTime.UtcNow,
                    OrderId = 1,
                    ItemId = 1,
                    Quantity = 3,
                }, new OrderItem
                {
                    RowId = 2,
                    LastModified = DateTime.UtcNow,
                    OrderId = 2,
                    ItemId = 2,
                    Quantity = 7,
                });
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.RowId);
                entity.Property(e => e.LastModified);
                entity.Property(e => e.ItemNumber).HasMaxLength(250);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Price);

                entity.HasData(new Item
                {
                    RowId = 1,
                    LastModified = DateTime.UtcNow,
                    ItemNumber = "Y_123",
                    Name = "Yeti Tumbler",
                    Price = 39.99m,
                }, new Item
                {
                    RowId = 2,
                    LastModified = DateTime.UtcNow,
                    ItemNumber = "AF_234",
                    Name = "Air Fryer",
                    Price = 138.95m,
                });
            });
        }
    }
}

