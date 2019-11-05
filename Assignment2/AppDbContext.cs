using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;
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
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.Waiter)
                .WithMany(w => w.WaiterTables)
                .HasForeignKey(wt => wt.WaiterName);
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.Table)
                .WithMany(t => t.WaiterTables)
                .HasForeignKey(wt => wt.TableNumber);

        }
    }
    


}
