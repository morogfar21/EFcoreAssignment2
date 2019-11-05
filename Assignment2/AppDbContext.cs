using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;
using Assignment2.ShadowModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment2
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=DAB2;Integrated Security=True");
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region RestaurantDishManyToMany

            modelBuilder.Entity<RestaurantDish>()
                .HasOne(rd => rd.Restaurant)
                .WithMany(r => r.RestaurantDishes)
                .HasForeignKey(rd => rd.ResturantAddress);
            modelBuilder.Entity<RestaurantDish>()
                .HasOne(rd => rd.Dish)
                .WithMany(d => d.RestaurantDishes)
                .HasForeignKey(rd => rd.DishType);
            #endregion

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

            #region WaiterTable

            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.Waiter)
                .WithMany(w => w.WaiterTables)
                .HasForeignKey(wt => wt.WaiterName);
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.Table)
                .WithMany(t => t.WaiterTables)
                .HasForeignKey(wt => wt.TableNumber);
            #endregion
        }

    }
    


}
