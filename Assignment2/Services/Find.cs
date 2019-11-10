using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.Models;

namespace Assignment2.Services
{
    public static class Find
    {
        public static Restaurant FindRestaurant(AppDbContext context)
        {
            Console.Write("Find restaurant address: ");
            string address = Console.ReadLine();

            return context.Restaurants.SingleOrDefault(r => r.Address == address);
        }

        public static Dish FindDish(AppDbContext context)
        {
            Console.Write("Dish Name: ");
            string type = Console.ReadLine();
                
            return context.Dishes.SingleOrDefault(d => d.Name == type);
        }

        public static Guest FindGuest(AppDbContext context)
        {
            Console.WriteLine("Guest Name: ");
            var name = Console.ReadLine();

            return context.Guests.SingleOrDefault(g => g.Name == name);
        }

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

            return context.Tables.Where(t => t.Number == number).SingleOrDefault();
        }
    }
}
