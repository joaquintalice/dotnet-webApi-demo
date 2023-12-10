using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options){}

        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Data seeding
            modelBuilder.Entity<Shirt>().HasData(
                    new Shirt() { Id = 1, Brand = "Nike", Color = "red", Gender = "men", Size = 8, Price = 49.99 },
                    new Shirt() { Id = 2, Brand = "Adidas", Color = "blue", Gender = "women", Size = 7, Price = 39.99 },
                    new Shirt() { Id = 3, Brand = "Puma", Color = "green", Gender = "men", Size = 12, Price = 29.99 },
                    new Shirt() { Id = 4, Brand = "Reebok", Color = "black", Gender = "women", Size = 6, Price = 59.99 },
                    new Shirt() { Id = 5, Brand = "Under Armour", Color = "gray", Gender = "men", Size = 9, Price = 79.99 },
                    new Shirt() { Id = 6, Brand = "Fila", Color = "white", Gender = "women", Size = 7, Price = 34.99 },
                    new Shirt() { Id = 7, Brand = "New Balance", Color = "purple", Gender = "men", Size = 10, Price = 54.99 },
                    new Shirt() { Id = 8, Brand = "Asics", Color = "yellow", Gender = "women", Size = 11, Price = 44.99 }
                );
        }
    }
}
