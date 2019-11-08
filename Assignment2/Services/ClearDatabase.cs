using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Services
{
    public class ClearDatabase
    {
        public void DeleteData(AppDbContext context)
        {
            context.Dishes.Remove(context.Dishes.Find(1));

            context.Guests.Remove(context.Guests.Find(1));

            //context.Persons.Remove(context.Persons.Find(1));

            context.Restaurants.Remove(context.Restaurants.Find(1));

            context.Reviews.Remove(context.Reviews.Find(1));

            context.Tables.Remove(context.Tables.Find(1));

            context.Waiters.Remove(context.Waiters.Find(1));
            context.SaveChanges();
        }
    }
}
