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
        //(type) -> list all restaurants with given type and their average rating + latest 5 review text
        public static void ListRestaurantByType(AppDbContext context)
        {
            Console.WriteLine("Write type of restaurant");
            var type = Console.ReadLine();

            var restaurants = context.Restaurants.Where(r => r.Type == type);
            Console.WriteLine($"\nRestaurants with {type}");
            foreach (var r in restaurants)
            {
                Console.WriteLine("--------------");
                Console.WriteLine($"\n{r.Name} Average rating: {CalculateAverageRating(r.Reviews)}");
                Console.WriteLine("\nLast 5 Reviews:\n");
                
                for (int i = 0; i < 5; i++)
                {
                    var reviewCount = r.Reviews.Count - i - 1;
                    if (reviewCount >=0)
                        Console.WriteLine($"Review nr {i+1}: {r.Reviews.ElementAt(reviewCount).Text}");
                }
            }
        }


        ////(type) -> list all restaurants with given type and their average rating + latest 5 review text
        //public static void ListRestaurantByType(AppDbContext context)
        //{
        //    Console.WriteLine("Write type of restaurant: ");
        //    string type = Console.ReadLine();
            
        //    List<Restaurant> list = context.Restaurants.Include(r => r.Reviews).ToList();


        //    foreach (var rest in list)
        //    {
        //        if (rest.Type == type)
        //        {
        //            double rating = CalculateAverageRating(rest.Reviews);
        //            Console.WriteLine($"Name: {rest.Name}\n $Average rating: {rating}");

        //            Console.WriteLine("Text from latest five reviews: ");
                    
        //            for (int i = 0; i < 5; i++)
        //            {
        //                Console.WriteLine(rest.Reviews[rest.Reviews.Count-1-i]);
        //            }
        //        }
        //    }
        //}

        private static double CalculateAverageRating(List<Review> revList)
        {
            double stars = 0;
            if (revList == null)
                return 0;
            foreach (var rev in revList)
            {
                stars += rev.Stars;
            }

            return (stars/revList.Count);
        }

        //(restaurant addr) -> menu - dishes, price, avg rating
        public static void ListRestaurantGeneralInformation(AppDbContext context)
        {
            var r = Find.FindRestaurant(context);
            if (r == null)
                return;

            var dishes = new List<Dish>();
            if (r.RestaurantDishes != null)
            {
                dishes.AddRange(r.RestaurantDishes.Select(rd => rd.Dish));
            }

            Console.WriteLine("Dishes:\n");
            foreach (var d in dishes)
            {
                Console.WriteLine($"{d.Name}, Price: {d.Price}");
            }

            Console.WriteLine($"\n ----- \n Average Rating: {CalculateAverageRating(r.Reviews)}\n ----- \n");
        }

        ////(restaurant addr) -> menu - dishes, price, avg rating
        //public static void ListRestaurantGeneralInformation(AppDbContext context)
        //{
        //    Restaurant res = Find.FindRestaurant(context);

        //    List<Restaurant> restaurants = context.Restaurants.
        //        Include(r => r.RestaurantDishes).ThenInclude(rd => rd.Dish)/*.Include(rw => rw.Reviews)*/.ToList();

        //    if (res != null)
        //    {
        //        foreach (var restaurant in restaurants)
        //        {
        //            Console.Write($"Restaurant - Name: {restaurant.Name}, ");
        //            foreach (var dish in restaurant.RestaurantDishes)
        //            {
        //                //Console.Write($"Dishes: {string.Join(", ", dish.Dish)} ");
        //                Console.Write($"Dish and price: {dish.Dish.Name} - ");
        //                Console.Write($"{dish.Dish.Price}$, ");
        //                //Console.Write($"Price: {string.Join(", ", dish.Dish.Price)} ");
        //            }
        //            double avgReview = CalculateAverageRating(restaurant.Reviews);
        //            Console.WriteLine($"Average rating: {avgReview}");
        //        }

        //        //Console.WriteLine(string.Join(",", restaurants));
        //    }
        //}

        //(restaurant addr) -> information about guests reviews for dishes based on table. 
        public static void ListRestaurantBasedOnTableReviews(AppDbContext context)
        {
            var tables = context.Tables.ToList();

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

        //(restaurant addr) -> information about guests reviews for dishes based on table. 
        public static void ListRestaurantBasedOnTableReviews2(AppDbContext context)
        {
            var r = Find.FindRestaurant(context);
            if (r == null)
            {
                Console.WriteLine("No restaurant with that Address");
                return;
            }
            Console.WriteLine("\nReviews based on tables");

            foreach (var t in r.Tables)
            {
                Console.WriteLine($"Table {t.Number}:");
                Console.WriteLine("----------");
                Console.WriteLine($"\nNumber of Guests: {t.Guests.Count}");
                Console.WriteLine("Reviews:\n");
                var reviews = new List<Review>();

                foreach (var g in t.Guests.Where(g => !reviews.Contains(g.Review)))
                {
                    var guestList = "Guests at table: ";
                    foreach (var guest in g.Review.Guests)
                    {
                        guestList += guest.Name + ", ";
                    }
                    Console.WriteLine($"{guestList}");
                    var dishList = "\nHad the following dishes: ";
                    

                    foreach (var d in g.Review.Dishes)
                    {
                        dishList += d.Name + ", ";
                    }
                    Console.WriteLine($"{dishList}");
                    Console.WriteLine($"Rating: {g.Review.Stars}");
                    Console.WriteLine("----------\n\n");

                    reviews.Add(g.Review);
                }

            }
        }
    }
}
