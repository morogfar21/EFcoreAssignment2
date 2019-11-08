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

        //    return context.Guests.Where(g => g.Time == time).Single();
        //}
        //public static Person FindPerson(AppDbContext context)
        //{
        //    Console.Write("Person Name: ");
        //    string name = Console.ReadLine();

        //    return context.Persons.Where(p => p.Name == name).SingleOrDefault();
        //}
        #endregion

        #region Bertram
        public static Restaurant FindRestaurant(AppDbContext context)
        {
            Console.Write("Restaurant address: ");
            string address = Console.ReadLine();

            return context.Restaurants.Where(r => r.Address == address).SingleOrDefault();

            //var res = context.Restaurants.Where(r => r.Address == address).SingleOrDefault();
            //if (res ==)
            //{

            //}

            //return 
        }

        public static Dish FindDish(AppDbContext context)
        {
            Console.Write("Dish type: ");
            string type = Console.ReadLine();

            return context.Dishes.Where(d => d.Type == type).SingleOrDefault();
        }
        #endregion

        #region Henrik

        public static Guest FindGuest(AppDbContext context)
        {
            Console.WriteLine("Guest Name: ");
            var name = Console.ReadLine();

            return context.Guests.Where(g => g.Name == name).SingleOrDefault();
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
