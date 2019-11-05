using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment2
{
    class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=DAB2;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RestaurantDish (many to many)
            modelBuilder.Entity<RestaurantDish>()
                .HasOne(rd => rd.Restaurant)
                .WithMany(r => r.RestaurantDishes)
                .HasForeignKey(rd => rd.ResturantAddress);
            modelBuilder.Entity<RestaurantDish>()
                .HasOne(rd => rd.Dish)
                .WithMany(d => d.RestaurantDishes)
                .HasForeignKey(rd => rd.DishType);
        }
    }
    


}
