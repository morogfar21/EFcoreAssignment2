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
        #endregion

        #region Frands
        #endregion
    }
}
