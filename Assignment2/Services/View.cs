using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.Models;
using Assignment2.ShadowModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Services
{
    public static class View
    {
        //(type) -> list all restaurants with give type and their average rating + latest 5 review text
        public static void ListRestaurantByType(AppDbContext context)
        {

        }

        //(restaurant addr) -> menu - dishes, price, avg rating
        public static void ListRestaurantGeneralInformation(AppDbContext context)
        {
            Restaurant res = Find.FindRestaurant(context);

            List<Restaurant> restaurants = context.Restaurants.
                Include(d => d.RestaurantDishes).ThenInclude(rd => rd.Dish).ToList();

            if (res != null)
            {
                foreach (var restaurant in restaurants)
                {
                    Console.Write($"Restaurant - Name: {restaurant.Name} ");
                    foreach (var dish in restaurant.RestaurantDishes)
                    {
                        Console.Write($"Dishes: {string.Join(", ", restaurant.RestaurantDishes)} ");
                        Console.Write($"Price: {string.Join(", ", dish.Dish.Price)} ");
                    }
                    Console.WriteLine($"Average rating: {restaurant.Reviews}");
                }
                //Console.WriteLine(string.Join(",", restaurants));
            }
        }

        //(restaurant addr) -> information about guests reviews for dishes based on table. 
        public static void ListRestaurantBasedOnTableReviews(AppDbContext context)
        {

        }


    }
}
