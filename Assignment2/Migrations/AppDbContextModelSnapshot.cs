﻿// <auto-generated />
using System;
using Assignment2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment2.Models.Dish", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Price");

                    b.Property<int?>("ReviewId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Name");

                    b.HasIndex("ReviewId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Assignment2.Models.Guest", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ReviewId");

                    b.Property<int?>("TableId");

                    b.Property<string>("Time")
                        .IsRequired();

                    b.HasKey("Name");

                    b.HasIndex("ReviewId");

                    b.HasIndex("TableId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Assignment2.Models.Restaurant", b =>
                {
                    b.Property<string>("Address")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Address");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Assignment2.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RestaurantAddress")
                        .IsRequired();

                    b.Property<double>("Stars");

                    b.Property<string>("Text");

                    b.HasKey("ReviewId");

                    b.HasIndex("RestaurantAddress");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Assignment2.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number");

                    b.Property<string>("RestaurantAddress")
                        .IsRequired();

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantAddress");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Assignment2.Models.Waiter", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Salary");

                    b.HasKey("Name");

                    b.ToTable("Waiters");
                });

            modelBuilder.Entity("Assignment2.ShadowModels.GuestDish", b =>
                {
                    b.Property<int>("GuestDishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DishName")
                        .IsRequired();

                    b.Property<string>("GuestName")
                        .IsRequired();

                    b.HasKey("GuestDishId");

                    b.HasIndex("DishName");

                    b.HasIndex("GuestName");

                    b.ToTable("GuestDish");
                });

            modelBuilder.Entity("Assignment2.ShadowModels.RestaurantDish", b =>
                {
                    b.Property<int>("RestaurantDishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("RestaurantAddress")
                        .IsRequired();

                    b.HasKey("RestaurantDishId");

                    b.HasIndex("Name");

                    b.HasIndex("RestaurantAddress");

                    b.ToTable("RestaurantDish");
                });

            modelBuilder.Entity("Assignment2.ShadowModels.WaiterTable", b =>
                {
                    b.Property<int>("WaiterTableId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TableId");

                    b.Property<string>("WaiterName")
                        .IsRequired();

                    b.HasKey("WaiterTableId");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterName");

                    b.ToTable("WaiterTable");
                });

            modelBuilder.Entity("Assignment2.Models.Dish", b =>
                {
                    b.HasOne("Assignment2.Models.Review", "Review")
                        .WithMany("Dishes")
                        .HasForeignKey("ReviewId");
                });

            modelBuilder.Entity("Assignment2.Models.Guest", b =>
                {
                    b.HasOne("Assignment2.Models.Review", "Review")
                        .WithMany("Guests")
                        .HasForeignKey("ReviewId");

                    b.HasOne("Assignment2.Models.Table", "Table")
                        .WithMany("Guests")
                        .HasForeignKey("TableId");
                });

            modelBuilder.Entity("Assignment2.Models.Review", b =>
                {
                    b.HasOne("Assignment2.Models.Restaurant", "Restaurant")
                        .WithMany("Reviews")
                        .HasForeignKey("RestaurantAddress")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assignment2.Models.Table", b =>
                {
                    b.HasOne("Assignment2.Models.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantAddress")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assignment2.ShadowModels.GuestDish", b =>
                {
                    b.HasOne("Assignment2.Models.Dish", "Dish")
                        .WithMany("GuestDishes")
                        .HasForeignKey("DishName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment2.Models.Guest", "Guest")
                        .WithMany("GuestDishes")
                        .HasForeignKey("GuestName")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Assignment2.ShadowModels.RestaurantDish", b =>
                {
                    b.HasOne("Assignment2.Models.Dish", "Dish")
                        .WithMany("RestaurantDishes")
                        .HasForeignKey("Name")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment2.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantDishes")
                        .HasForeignKey("RestaurantAddress")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Assignment2.ShadowModels.WaiterTable", b =>
                {
                    b.HasOne("Assignment2.Models.Table", "Table")
                        .WithMany("WaiterTables")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment2.Models.Waiter", "Waiter")
                        .WithMany("WaiterTables")
                        .HasForeignKey("WaiterName")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
