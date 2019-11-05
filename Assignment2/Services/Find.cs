using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.Models;

namespace Assignment2.Services
{
    public static class Find
    {
        #region Marcus
        #endregion

        #region Bertram
        public static Restaurant FindRestaurant(AppDbContext context)
        {
            Console.Write("Restaurant address: ");
            string address = Console.ReadLine();

            return context.Restaurants.Where(r => r.Address == address).Single();
        }

        public static Dish FindDish(AppDbContext context)
        {
            Console.Write("Dish type: ");
            string type = Console.ReadLine();

            return context.Dishes.Where(d => d.Type == type).Single();
        }
        #endregion

        #region Henrik

        public static Review FindReview(AppDbContext context)
        {
            Console.WriteLine("Review Id: ");
            int reviewId = int.Parse(Console.ReadLine());

            return context.Reviews.Where(r => r.ReviewId == reviewId).Single();
        }

        public static Guest FindGuest(AppDbContext context)
        {
            Console.WriteLine("Guest Name: ");
            var name = Console.ReadLine();

            return context.Guests.Where(g => g.Name == name).Single();
        }

        #endregion

        #region Frands

        public static Waiter FindWaiter(AppDbContext context)
        {
            Console.Write("Waiter name: ");
            string name = Console.ReadLine();

            return context.Waiters.Where(w => w.Name == name).Single();
        }

        public static Table FindTable(AppDbContext context)
        {
            Console.Write("Number of table: ");
            int number = int.Parse(Console.ReadLine());

            return context.Tables.Where(w => w.Number == number).Single();
        }

        #endregion
    }
}
