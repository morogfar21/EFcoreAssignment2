using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;

namespace Assignment2.Services
{
    public class DummyData
    {
        public void InsertAllDummyData(AppDbContext context)
        {
            InsertDummyDishes(context,"Breakfast",0,10);
            InsertDummyDishes(context, "Dinner", 10, 10);
            InsertDummyDishes(context, "Supper", 20, 10);
            InsertDummyDishes(context, "Snack", 30, 10);
        }
        #region Henrik

        public void InsertDummyDishes(AppDbContext context,string type, float price, int numberOfDishes)
        {

            for (int i = 0; i < numberOfDishes; i++)
            {
                var dish = new Dish();

                dish.Name = "Dish" + i.ToString();
                dish.Type = type;
                dish.Price = price + i;
                context.Dishes.Add(dish);
            }
            
        }
        #endregion

        #region Frands
        #endregion

        #region Bertram
        #endregion

        #region Marcus
        #endregion
    }
}
