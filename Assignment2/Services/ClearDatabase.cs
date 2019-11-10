using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Services
{
    public static class ClearDatabase
    {
        public static void DeleteData(AppDbContext context)
        {
            if (DummyData.DummyDataInserted)
            {
                context.RemoveRange(context.Dishes);
                context.RemoveRange(context.Guests);
                context.RemoveRange(context.Restaurants);
                context.RemoveRange(context.Reviews);
                context.RemoveRange(context.Tables);
                context.RemoveRange(context.Waiters);
                context.SaveChanges();
                DummyData.DummyDataInserted = false;
            }
        }
    }
}
