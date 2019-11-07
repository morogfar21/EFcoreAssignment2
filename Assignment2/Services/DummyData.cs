using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.Models;
using Assignment2.ShadowModels;

namespace Assignment2.Services
{
    public class DummyData
    {
        private List<Restaurant> _restaurants;
        private List<Dish> _dishes;

        public void InsertAllDummyData(AppDbContext context)
        {
            _restaurants = new List<Restaurant>();
            _dishes = new List<Dish>();
            InsertDummyDishes(context,"Appertice",0,10);
            InsertDummyDishes(context, "MainCourse", 10, 10);
            InsertDummyDishes(context, "Dessert", 20, 10);
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
                
                var restaurant = context.Restaurants.Where(r => r.Address == ("Adress" + i)).Single();
                
                if (restaurant != null)
                {
                    dish.RestaurantDishes = new List<RestaurantDish>()
                    {
                        new RestaurantDish()
                        {
                            Restaurant = restaurant,
                            Dish = dish,
                        }
                    };
                }
                context.Dishes.Add(dish);
            }

            
            
        }


        public void InsertDummyReview(AppDbContext context, string )
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
