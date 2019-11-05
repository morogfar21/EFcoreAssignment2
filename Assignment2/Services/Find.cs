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
        #endregion

        #region Henrik

        public static Review FindReview(AppDbContext context)
        {
            Console.WriteLine("Review Id: ");
            int reviewId = int.Parse(Console.ReadLine());

            return context.Reviews.Where(r => r.ReviewId == reviewId).Single();
        }

        public static Restaurant FindGuest(AppDbContext context)
        {
            Console.WriteLine("Guest Name: ");
            var name = Console.ReadLine();

            return context.Guests.Where(g => g.Name == name).Single();
        }

        #endregion

        #region Frands
        #endregion
    }
}
