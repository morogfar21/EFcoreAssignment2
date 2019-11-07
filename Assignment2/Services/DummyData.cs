﻿using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.ShadowModels;
using System.Linq;

namespace Assignment2.Services
{
    public class DummyData
    {
        public void InsertAllDummyData(AppDbContext context,int amountOfData)
        {
            //Inserting Dishes
            InsertDummyDishes(context,amountOfData);

            //Inserting Restaurants
            InsertDummyRestaurant(context, amountOfData);

            //Inserting Reviews
            InsertDummyReview(context, "Review text says this", amountOfData, amountOfData);

            //Inserting Tables
            //Inserting Waiters
            InsertDummyWaiters(context, amountOfData);
            //Inserting Guests
            InsertDummyGuest(context, "Guest", amountOfData, 5, 5);
            context.SaveChanges();
        }
        #region Henrik

        public void InsertDummyDishes(AppDbContext context, int numberOfDishes)
        {
            string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random randDishType = new Random();

            for (int i = 0; i < numberOfDishes; i++)
            {
                var dish = new Dish();

                dish.Name = "Dish" + i;
                dish.Type = dishTypeArray[randDishType.Next(dishTypeArray.Length - 1)];
                dish.Price = 10 * i;
                
                var restaurant = context.Restaurants.Where(r => r.Address == ("Adress" + i)).Single();
                
                if (restaurant != null)
                {
                    dish.RestaurantDishes = new List<RestaurantDish>()
                    {
                        new RestaurantDish()
                        {
                            Restaurant = restaurant,
                            Dish = dish,
                        }
                    };
                }
                context.Dishes.Add(dish);
            }
        }

        public void InsertDummyTable(AppDbContext context, int numberOfTables)
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
                    r.Tables.Add(table);
                    context.Tables.Add(table);
                }
            }
        }

        #endregion

        #region Frands
        #endregion

        #region Bertram
        public void InsertDummyRestaurant(AppDbContext context, int numberOfRestaurants)
        {
            string[] restaurantTypeArray = { "Breakfast", "Dinner", "Supper"};
            Random rand1 = new Random();

            string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random rand2 = new Random();

            for (int i = 0; i < numberOfRestaurants; i++)
            {
                string restaurantType = restaurantTypeArray[rand1.Next(restaurantTypeArray.Length-1)];
                string dishType = dishTypeArray[rand2.Next(dishTypeArray.Length-1)];

                Dish dish = context.Dishes.Where(d => d.Type == dishType).Single();

                Restaurant restaurant = new Restaurant()
                {
                    Name = "Restaurant" + i,
                    Type = restaurantType,
                    Address = "Address" + i
                };

                if (dish != null)
                {
                    restaurant.RestaurantDishes = new List<RestaurantDish>()
                    {
                        new RestaurantDish()
                        {
                            Restaurant = restaurant,
                            Dish = dish
                        }
                    };
                }
                context.Restaurants.Add(restaurant);
            }
        }

        public void InsertDummyReview(AppDbContext context, string text, int numberOfReviews, int numberOfRestaurantsToReview)
        {
            int[] numStarsArray = { 1,2,3,4,5 };
            Random rand = new Random();
            int randomIndex = rand.Next(numStarsArray.Length);

            for (int index = 0; index < numberOfRestaurantsToReview; index++)
            {
                Restaurant restaurant = context.Restaurants.Where(r => r.Address == "Address" + index).Single();

                for (int i = 0; i < numberOfReviews; i++)
                {
                    int numStars = numStarsArray[randomIndex];

                    if (restaurant != null)
                    {
                        Review review = new Review()
                        {
                            Text = text + i,
                            Stars = numStars,
                            Restaurant = restaurant
                        };
                        context.Reviews.Add(review);
                    }
                }
            }
        }

        public void InsertDummyGuest(AppDbContext context, string name, int numberOfGuestsToAdd, int numberOfRestaurantsToAddGuestsTo, int numberOfTablesToAddGuestsTo)
        {
            for (int i = 0; i < numberOfRestaurantsToAddGuestsTo; i++)
            {
                Restaurant restaurant = context.Restaurants.Where(r => r.Address == "Address" + i).Single();

                for (int j = 0; j < numberOfTablesToAddGuestsTo; j++)
                {
                    Table table = context.Tables.Where(t => t.Number == j).Single();

                    for (int k = 0; k < numberOfGuestsToAdd; k++)
                    {
                        if (restaurant != null && table != null)
                        {
                            Guest guest = new Guest()
                            {
                                Name = name+k+"R"+i,
                                Time = "01:01:2000",
                                Table = table
                            };
                        }
                    }
                }
            }
        }
        #endregion

        #region Marcus
        public void InsertDummyWaiters(AppDbContext context, int numberOfWaiters)
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
                    waiter.WaiterTables = new List<WaiterTable>()
                    {
                        new WaiterTable()
                        {
                            Waiter = waiter,
                            Table = t
                        }
                    };
                    context.Waiters.Add(waiter);
                    waiterCount++;
                }
            }
        }
        #endregion
    }
}
