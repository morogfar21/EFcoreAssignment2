using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;

namespace Assignment2.Services
{
    public class DummyData
    {
        #region Henrik
        #endregion

        #region Frands
        #endregion

        #region Bertram
        public void InsertDummyRestaurant(AppDbContext context, string name, string restaurantType, /*string dishType,*/ string address, int numberOfRestaurants)
        {
            string[] typeArray = { "Breakfast", "Dinner", "Supper", "Snack" };
            Random rand = new Random();
            int randomIndex = rand.Next(typeArray.Length);
            string dishType = typeArray[randomIndex];

            for (int i = 0; i < numberOfRestaurants; i++)
            {
                Restaurant restaurant = new Restaurant()
                {
                    Name = name+i,
                    Type = restaurantType+i,
                    Address = address+i
                };

                restaurant.RestaurantDishes = new List<RestaurantDish>()
                {
                    new RestaurantDish()
                    {
                        RestaurantAddress = address+i,
                        DishType = dishType
                    }
                };
                context.Restaurants.Add(restaurant);
            }
        }
        #endregion

        #region Marcus
        #endregion
    }
}
