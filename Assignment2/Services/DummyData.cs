﻿using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.ShadowModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment2.Services
{
    public static class DummyData
    {
        public static bool DummyDataInserted = false;
        public static void InsertAllDummyData(AppDbContext context,int amountOfData)
        {
            if (!DummyDataInserted)
            {
                //Inserting Restaurants
                InsertDummyRestaurant(context, amountOfData);

                //Inserting Tables
                InsertDummyTable(context, amountOfData);

                //Inserting Dishes
                InsertDummyDishes(context, amountOfData);

                //Inserting Waiters
                InsertDummyWaiters(context, amountOfData);
                //Inserting Guests
                InsertDummyGuest(context, amountOfData);

                //Inserting Reviews
                InsertDummyReview(context, amountOfData);
                context.SaveChanges();
                DummyDataInserted = true;
                Console.WriteLine("DummyData inserted");
            }
            else
            {
                Console.WriteLine("DummyData already inserted!");
            }
        }

        private static void InsertDummyDishes(AppDbContext context, int numberOfDishes)
        {
            string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random randDishType = new Random();
            var dishCount = 0;

            var restaurants = context.Restaurants;

            foreach (var r in restaurants)
            {
                if (r.RestaurantDishes == null)
                    r.RestaurantDishes = new List<RestaurantDish>();
                for (int i = 0; i < numberOfDishes; i++)
                {
                    var dish = new Dish()
                    {
                        Name = "Dish" + dishCount++,
                        Type = dishTypeArray[randDishType.Next(dishTypeArray.Length - 1)],
                        Price = 10 * numberOfDishes
                    };
                    var rd = new RestaurantDish()
                    {
                        Dish = dish,
                        Restaurant = r
                    };
                    r.RestaurantDishes.Add(rd);
                }
                
            }

            for (int i = 0; i < numberOfDishes; i++)
            {
                var dish = new Dish();

                dish.Name = "Dish" + i;
                dish.Type = dishTypeArray[randDishType.Next(dishTypeArray.Length - 1)];
                dish.Price = 10 * i;
                
                var restaurant = context.Restaurants.SingleOrDefault(r => r.Address == ("Adress" + i));
                
                if (restaurant != null)
                {
                    if (dish.RestaurantDishes == null)
                        dish.RestaurantDishes = new List<RestaurantDish>();

                    var restaurantDish = new RestaurantDish()
                    {
                        Restaurant = restaurant,
                        Dish = dish,
                    };

                    dish.RestaurantDishes.Add(restaurantDish);
                }
                context.Dishes.Add(dish);
            }

            context.SaveChanges();
        }

        private static void InsertDummyTable(AppDbContext context, int numberOfTables)
        {
            var restaurants = context.Restaurants;


            foreach (var r in restaurants)
            {
                for (int i = 0; i < numberOfTables; i++)
                {
                    var table = new Table()
                    {
                        Number = i,
                        Restaurant = r
                    };
                    if (r.Tables == null)
                        r.Tables = new List<Table>();
                    r.Tables.Add(table);
                    context.Tables.Add(table);
                }
            }
            context.SaveChanges();
        }

        private static void InsertDummyRestaurant(AppDbContext context, int numberOfRestaurants)
        {
            string[] restaurantTypeArray = { "Breakfast", "Dinner", "Supper"};
            Random rand1 = new Random();

            //string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random rand2 = new Random();

            for (int i = 0; i < numberOfRestaurants; i++)
            {
                string restaurantType = restaurantTypeArray[rand1.Next(restaurantTypeArray.Length-1)];
                //string dishType = dishTypeArray[rand2.Next(dishTypeArray.Length-1)];

                Restaurant restaurant = new Restaurant()
                {
                    Name = "Restaurant" + i,
                    Type = restaurantType,
                    Address = "Address" + i,
                    Reviews = new List<Review>(),
                    Tables = new List<Table>()
                };

                context.Restaurants.Add(restaurant);
            }
            context.SaveChanges();
        }

        private static void InsertDummyReview(AppDbContext context, int numberOfReviews )//int numberOfRestaurantsToReview)
        {
            var restaurants = context.Restaurants;
            
            var reviewNumber = 0;
            var rand = new Random();
            foreach (var r in restaurants)
            {
                foreach (var t in r.Tables)
                {
                    var review = new Review {Restaurant = r};

                    if (t.Guests == null)
                        t.Guests = new List<Guest>();

                    if (review.Guests == null)
                        review.Guests = new List<Guest>();

                    foreach (var g in t.Guests)
                    {
                        review.Guests.Add(g);
                        foreach (var gd in g.GuestDishes)
                        {
                            if (review.Dishes == null)
                                review.Dishes = new List<Dish>();
                            review.Dishes.Add(gd.Dish);
                        }
                    }

                    review.Text = "Text for review" + reviewNumber++;
                    review.Stars = rand.Next(1, 5);

                    if (r.Reviews==null)
                        r.Reviews = new List<Review>();
                    r.Reviews.Add(review);

                    context.Reviews.Add(review);
                }
            }
            context.SaveChanges();

        }

        private static void InsertDummyGuest(AppDbContext context,  int numberOfGuestsToAdd)
        {
            var restaurants = context.Restaurants;
            
            var guestCount = 0;

            var rand = new Random();
            foreach (var r in restaurants)
            {
                var dishes = r.RestaurantDishes.Select(rd => rd.Dish).ToList();

                foreach (var t in r.Tables)
                {
                    for (var i = 0; i < numberOfGuestsToAdd; i++)
                    {
                        var guest = new Guest()
                        {
                            Name = "Guest" + guestCount++,
                            Time = "01:01:2000",
                            Table = t,
                        };
                        for (var index = 0; index < 3; index++)
                        {
                            var guestDish = new GuestDish()
                            {
                                Guest = guest,
                                Dish = dishes[rand.Next(0, dishes.Count - 1)]
                            };
                            if (guest.GuestDishes == null)
                                guest.GuestDishes = new List<GuestDish>();
                            guest.GuestDishes.Add(guestDish);
                        }
                        if (t.Guests == null)
                            t.Guests = new List<Guest>();
                        t.Guests.Add(guest);
                        context.Guests.Add(guest);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void InsertDummyWaiters(AppDbContext context, int numberOfWaiters)
        {
            var tables = context.Tables;
            int waiterCount = 0;

            foreach (var t in tables)
            {
                for (int i = 0; i < numberOfWaiters; i++)
                {
                    var waiter = new Waiter()
                    {
                        Name = "Waiter"+ waiterCount,
                        Salary = waiterCount * 100
                    };
                    if (waiter.WaiterTables == null)
                        waiter.WaiterTables = new List<WaiterTable>();

                    var waiterTable = new WaiterTable()
                    {
                        Waiter = waiter,
                        Table = t
                    };
                    waiter.WaiterTables.Add(waiterTable);
                    context.Waiters.Add(waiter);
                    waiterCount++;
                }
            }
            context.SaveChanges();
        }
    }
}
