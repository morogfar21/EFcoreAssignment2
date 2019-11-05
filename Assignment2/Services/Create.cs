using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;

namespace Assignment2.Services
{
    public static class Create
    {
        #region Marcus
        #endregion

        #region Bertram
        public static Restaurant CreateRestaurant()
        {
            Console.Write("Name of restaurant: ");
            string name = Console.ReadLine();

            Console.Write("Type (Breakfast, Dinner, Buffet...): ");
            string type = Console.ReadLine();

            Console.Write("Restaurant address: ");
            string address = Console.ReadLine();
            
            return new Restaurant()
            {
                Name = name,
                Type = type,
                Address = address
            };
        }

        public static Review CreateReview()
        {

        }
        #endregion

        #region Henrik

        public static Dish CreateDish(AppDbContext context)
        {
            Review review = Find.FindReview(context);

            Console.WriteLine("Input Type: ");
            string type = Console.ReadLine();

            Console.WriteLine("Input Price: ");
            int price = int.Parse(Console.ReadLine());

            return new Dish()
            {
                    Type = type,
                    Price = price,
                    Review = review,


            }
        }

        #endregion

        #region Frands
        #endregion
    }
}
