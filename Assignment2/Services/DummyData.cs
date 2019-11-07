using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;
using System.Linq;

namespace Assignment2.Services
{
    public class DummyData
    {
        public void InsertAllDummyData(AppDbContext context)
        {
            //Inserting Dishes
            InsertDummyDishes(context,"Breakfast",0,10);
            InsertDummyDishes(context, "Dinner", 10, 10);
            InsertDummyDishes(context, "Supper", 20, 10);
            InsertDummyDishes(context, "Snack", 30, 10);

            //Inserting Restaurants
            InsertDummyRestaurant(context, "Restaurant", "Address", 5);

            //Inserting Waiters

            //Inserting Guests

            //Inserting Reviews

            //Inserting Tables
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
        public void InsertDummyRestaurant(AppDbContext context, string name, /*string restaurantType*/ /*string dishType,*/ string address, int numberOfRestaurants)
        {
            string[] restaurantTypeArray = { "Breakfast", "Dinner", "Supper"};
            Random rand1 = new Random();
            int randomIndex1 = rand1.Next(restaurantTypeArray.Length);


            string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random rand2 = new Random();
            int randomIndex2 = rand2.Next(dishTypeArray.Length);


            for (int i = 0; i < numberOfRestaurants; i++)
            {
                string restaurantType = restaurantTypeArray[randomIndex1];
                string dishType = dishTypeArray[randomIndex2];

                Dish dish = context.Dishes.Where(d => d.Type == dishType).Single();

                Restaurant restaurant = new Restaurant()
                {
                    Name = name+i,
                    Type = restaurantType,
                    Address = address+i
                };

                if (dish != null)
                {
                    restaurant.RestaurantDishes = new List<RestaurantDish>()
                    {
                        new RestaurantDish()
                        {
                            Restaurant = restaurant,
                            Dish = dish
                        }
                    };
                }
                context.Restaurants.Add(restaurant);
            }
        }

        public void InsertDummyReview(AppDbContext context, string text, int stars)
        {
            Review review = new Review()
            {
                Text = text,
                Stars = stars
            };
            context.Reviews.Add(review);
        }
        #endregion

        #region Marcus
        #endregion
    }
}
