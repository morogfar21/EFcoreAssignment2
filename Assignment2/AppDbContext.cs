using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment2
{
    class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=DAB2;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region GuestDish

            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Guest)
                .WithMany(d => d.GuestDishes)
                .HasForeignKey(gd => gd.GuestName);
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Dish)
                .WithMany(d => d.GuestDishes)
                .HasForeignKey(gd => gd.DishType);

            #endregion


        }

    }
    


}
