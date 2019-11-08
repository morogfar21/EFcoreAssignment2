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
        //public static Guest FindGuest(AppDbContext context)
        //{
        //    Console.Write("Time of review dd:mm:yyyy : ");
        //    int time = int.Parse(Console.ReadLine());
        //  return context.Guests.Where(g => g.Time == time).SingleOrDefault();
        //}
        //public static Person FindPerson(AppDbContext context)
        //{
        //    Console.Write("Person Name: ");
        //    string name = Console.ReadLine();

        //    return context.Persons.SingleOrDefault(p => p.Name == name);
        //}
        #endregion

        #region Bertram
        public static Restaurant FindRestaurant(AppDbContext context)
        {
            Console.Write("Restaurant address: ");
            string address = Console.ReadLine();

            return context.Restaurants.SingleOrDefault(r => r.Address == address);
        }

        public static Dish FindDish(AppDbContext context)
        {
            Console.Write("Dish type: ");
            string type = Console.ReadLine();

            return context.Dishes.SingleOrDefault(d => d.Type == type);
        }
        #endregion

        #region Henrik

        public static Guest FindGuest(AppDbContext context)
        {
            Console.WriteLine("Guest Name: ");
            var name = Console.ReadLine();

            return context.Guests.SingleOrDefault(g => g.Name == name);
        }

        #endregion

        #region Frands

        public static Waiter FindWaiter(AppDbContext context)
        {
            Console.Write("Waiter name: ");
            string name = Console.ReadLine();

            return context.Waiters.Where(w => w.Name == name).SingleOrDefault();
        }

        public static Table FindTable(AppDbContext context)
        {
            Console.Write("Number of table: ");
            int number = int.Parse(Console.ReadLine());

            return context.Tables.Where(w => w.Number == number).SingleOrDefault();
        }

        #endregion
    }
}
