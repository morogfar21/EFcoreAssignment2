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
        public static Table CreateTable(AppDbContext context)
        {
            Restaurant restaurant = Find.FindRestaurant(context);
            Waiter waiter = Find.FindWaiter()

            Console.Write("Number of table: ");
            int number = int.Parse(Console.ReadLine());

            Table table = new Table()
            {
                Number = number,
                Restaurant = restaurant
            };



            //[Key]
            //public int Number { get; set; }
            //public List<WaiterTable> WaiterTables { get; set; }
            //[Required]
            //public Restaurant Restaurant { get; set; }
            //public List<Guest> Guests { get; set; }
            
        }
        #endregion
    }
}
