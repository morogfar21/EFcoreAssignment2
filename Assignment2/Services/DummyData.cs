using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.ShadowModels;
using System.Linq;

namespace Assignment2.Services
{
    public class DummyData
    {
        public void InsertAllDummyData(AppDbContext context,int amountOfData)
        {
            //Inserting Dishes
            InsertDummyDishes(context,"Breakfast",0, amountOfData);
            InsertDummyDishes(context, "Dinner", 10, amountOfData);
            InsertDummyDishes(context, "Supper", 20, amountOfData);
            InsertDummyDishes(context, "Snack", 30, amountOfData);

            //Inserting Restaurants
            InsertDummyRestaurant(context, "Restaurant", "Address", amountOfData);

            //Inserting Waiters
            InsertDummyWaiters(context, amountOfData);
            //Inserting Guests
            InsertDummyGuest(context, "Guest", amountOfData, 5, 5);

            //Inserting Reviews
            InsertDummyReview(context, "Text", amountOfData, amountOfData);

            //Inserting Tables

            context.SaveChanges();
        }
        #region Henrik

        public void InsertDummyDishes(AppDbContext context,string type, float price, int numberOfDishes)
        {

            for (int i = 0; i < numberOfDishes; i++)
            {
                var dish = new Dish();

                dish.Name = "Dish" + i;
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

        public void InsertDummyTable(AppDbContext context, int numberOfTables)
        {
            var restaurants = context.Restaurants;
            foreach (var r in restaurants)
            {
                for (int i = 0; i < numberOfTables; i++)
                {
                    var table = new Table()
                    {
                        Number = i,
                        Restaurant = r
                    };
                    r.Tables.Add(table);
                    context.Tables.Add(table);
                }
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

        public void InsertDummyReview(AppDbContext context, string text, int numberOfReviews, int numberOfRestaurantsToReview)
        {
            int[] numStarsArray = { 1,2,3,4,5 };
            Random rand = new Random();
            int randomIndex = rand.Next(numStarsArray.Length);

            for (int index = 0; index < numberOfRestaurantsToReview; index++)
            {
                Restaurant restaurant = context.Restaurants.Where(r => r.Address == "Address" + index).Single();

                for (int i = 0; i < numberOfReviews; i++)
                {
                    int numStars = numStarsArray[randomIndex];

                    if (restaurant != null)
                    {
                        Review review = new Review()
                        {
                            Text = text + i,
                            Stars = numStars,
                            Restaurant = restaurant
                        };
                        context.Reviews.Add(review);
                    }
                }
            }
        }

        public void InsertDummyGuest(AppDbContext context, string name, int numberOfGuestsToAdd, int numberOfRestaurantsToAddGuestsTo, int numberOfTablesToAddGuestsTo)
        {
            //for (int i = 0; i < numberOfRestaurantsToAddGuestsTo; i++)
            //{
            //    Restaurant restaurant = context.Restaurants.Where(r => r.Address == "Address" + i).Single();

            //    for (int j = 0; j < numberOfTablesToAddGuestsTo; j++)
            //    {
            //        Table table = context.Tables.Where(t => t.Number == j).Single();

            //        for (int k = 0; k < numberOfGuestsToAdd; k++)
            //        {
            //            if (restaurant != null && table != null)
            //            {
            //                Guest guest = new Guest()
            //                {
            //                    Name = name+k+"R"+i,
            //                    Time = "01:01:2000",
            //                    Table = table
            //                };
            //            }
            //        }
            //    }
            //}

            var restaurants = context.Restaurants;
            var tables = context.Tables;
            int guestCount = 0;

            foreach (var r in restaurants)
            {
                foreach (var t in tables)
                {
                    for (int i = 0; i < numberOfGuestsToAdd; i++)
                    {
                        var guest = new Guest()
                        {
                            Name = "Guest" + guestCount,
                            Time = "01:01:2000",
                            Table = t
                        };
                        t.Guests.Add(guest);
                        context.Guests.Add(guest);
                        guestCount++;
                    }
                }
            }

        }
        #endregion

        #region Marcus
        public void InsertDummyWaiters(AppDbContext context, int numberOfWaiters)
        {
            var tables = context.Tables;
            int waiterCount = 0;

            foreach (var t in tables)
            {
                for (int i = 0; i < numberOfWaiters; i++)
                {
                    var waiter = new Waiter()
                    {
                        Name = "Waiter"+ waiterCount,
                        Salary = waiterCount * 100
                    };
                    waiter.WaiterTables = new List<WaiterTable>()
                    {
                        new WaiterTable()
                        {
                            Waiter = waiter,
                            Table = t
                        }
                    };
                    context.Waiters.Add(waiter);
                    waiterCount++;
                }
            }
        }
        #endregion
    }
}
