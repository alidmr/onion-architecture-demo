using System;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Pencil", Amount = 10, Quantity = 100 },
                new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Amount = 1, Quantity = 200 },
                new Product() { Id = Guid.NewGuid(), Name = "Book", Amount = 30, Quantity = 500 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
