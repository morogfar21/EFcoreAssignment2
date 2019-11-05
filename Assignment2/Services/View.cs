using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

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

        }

        //(restaurant addr) -> information about guests reviews for dishes based on table.
        public static void ListRestaurantBasedOnTableReviews(AppDbContext context)
        {

        }


    }
}
