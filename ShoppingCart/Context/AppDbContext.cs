using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using ShoppingCart.Helpers;
using ShoppingCart.Models;

namespace ShoppingCart.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars {get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Marker> Markers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new User[]
                {
                    new User()
                    {
                        Id = 1,
                        UserName = "Admin",
                        Email = "admin@gmail.com",
                        Password = HashPasswordHelper.HashPassowrd("123456"),
                        Role = Role.Admin
                    },
                });
            });

            modelBuilder.Entity<Marker>(builder =>
            {
                builder.ToTable("Markers").HasKey(x => x.Id);
                builder.ToTable("Markers").HasIndex(x => x.Description).IsUnique();

                builder.HasData(new Marker[]
                {
                    new Marker()
                    {
                        Id = 1,
                        Latitude = "55.028505",
                        Longitude = "82.937123",
                        Description = "ТРЦ Аура"
                    }
                });
            });
        }
    }
}
