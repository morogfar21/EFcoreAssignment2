using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Linq;
using System.Text;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Services
{
    public static class View
    {
        //(type) -> list all restaurants with give type and their average rating + latest 5 review text
        public static void ListRestaurantByType(AppDbContext context)
        {
            Console.WriteLine("Write type of dish: ");
            string type = Console.ReadLine();
            
            List<Restaurant> list = context.Restaurants.Include(r => r.Reviews).ToList();


            foreach (var rest in list)
            {
                if (rest.Type == type)
                {
                    double rating = CalculateAverageRating(rest.Reviews);
                    Console.WriteLine($"Name: {rest.Name}\n $Average rating: {rating}");

                    Console.WriteLine("Text from latest five reviews: ");
                    
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(rest.Reviews[rest.Reviews.Count-1-i]);
                    }
                }
            }
        }

        private static double CalculateAverageRating(List<Review> revList)
        {
            double stars = 0;
            foreach (var rev in revList)
            {
                stars += rev.Stars;
            }

            return (stars/revList.Count);
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
            List<Table> tables = context.Tables.ToList();

            foreach (var t in tables)
            {
                Console.WriteLine($"Reviews for Table: {t.Number}\n --------- \n");
                foreach (var g in t.Guests)
                {
                    Console.WriteLine($"Guest: {g.Name}\n Rating: {g.Review.Stars} Stars\n Had: \n");
                    foreach (var dish in g.GuestDishes)
                    {
                        Console.WriteLine($"{dish.Dish.Name}\n");
                    }
                    Console.WriteLine($"\nComments:\n{g.Review.Text}\n\n\n");
                }
                Console.WriteLine("\n---------\n---------\n\n");
            }
        }
    }
}
