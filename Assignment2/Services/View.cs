﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.Models;

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

        }

        //(restaurant addr) -> information about guests reviews for dishes based on table.
        public static void ListRestaurantBasedOnTableReviews(AppDbContext context, string address)
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
