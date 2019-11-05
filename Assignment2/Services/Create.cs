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

        public static Dish CreateDish(MyDbContext context)
        {
            Review review = Find.FindReview(context);

            
        }

        #endregion

        #region Frands
        #endregion
    }
}
