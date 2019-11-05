using System;
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

        public static Dish CreateDish(MyDbContext context)
        {
            Review review = Find.FindReview(context);

            
        }

        #endregion

        #region Frands
        #endregion
    }
}
