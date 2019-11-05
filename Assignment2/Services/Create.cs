﻿using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;
using Assignment2.ShadowModels;

namespace Assignment2.Services
{
    public static class Create
    {
        #region Marcus
        /*
        public static Person CreatePerson (AppDbContext context)
        {
            Console.Write("FirstName: ");
            string firstName = Console.ReadLine();

            Person person = new Person()
            {
                Name = firstName,
            };
            return person;

            //public List<GuestDish> GuestDishes;
            // public int Time;
        }
        public static Guest CreateGuest(AppDbContext context)
        {
            Console.Write("FirstName: ");
            string firstName = Console.ReadLine();

            Person person = new Person()
            {
                Name = firstName,
            };
            return person;

            //public List<GuestDish> GuestDishes;
            // public int Time;
        }
        */
        #endregion

        #region Bertram
        public static Restaurant CreateRestaurant(AppDbContext context)
        {
            Dish dish = Find.FindDish(context);

            Console.Write("Name of restaurant: ");
            string name = Console.ReadLine();

            Console.Write("Type (Breakfast, Dinner, Buffet...): ");
            string type = Console.ReadLine();

            Console.Write("Restaurant address: ");
            string address = Console.ReadLine();
            
            Restaurant restaurant = new Restaurant()
            {
                Name = name,
                Type = type,
                Address = address
            };

            if (dish != null)
            {
                restaurant.RestaurantDishes = new List<RestaurantDish>()
                {
                    new RestaurantDish()
                    {
                        ResturantAddress = address,
                        DishType = type
                    }
                };
            }
            return restaurant;
        }

        public static Review CreateReview(AppDbContext context)
        {
            Restaurant restaurant = Find.FindRestaurant(context);

            Console.Write("Text in review: ");
            string text = Console.ReadLine();

            Console.Write("Stars: ");
            int stars = int.Parse(Console.ReadLine());

            return new Review()
            {
                Text = text,
                Stars = stars,
                Restaurant = restaurant
            };
        }
        #endregion

        #region Henrik

        public static Dish CreateDish(AppDbContext context)
        {
            var review = Find.FindReview(context);
            var restaurant = Find.FindRestaurant(context);
            var guest = Find.FindGuest(context);

            Console.WriteLine("Input Dish Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Input Type: ");
            var type = Console.ReadLine();

            Console.WriteLine("Input Price: ");
            var price = int.Parse(Console.ReadLine());

            Dish dish = new Dish()
            {
                Name = name,
                Type = type,
                Price = price,
            };

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

            if (guest != null)
            {
                dish.GuestDishes = new List<GuestDish>()
                {
                    new GuestDish()
                    {
                        Guest = guest,
                        Dish = dish,
                    }
                };
            }

            return dish;
        }

        #endregion

        #region Frands
        #endregion
    }
}
