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
            //Inserting Restaurants
            InsertDummyRestaurant(context, amountOfData);

            //Inserting Tables
            InsertDummyTable(context,amountOfData);

            //Inserting Dishes
            InsertDummyDishes(context, amountOfData);

            //Inserting Waiters
            InsertDummyWaiters(context, amountOfData);
            //Inserting Guests
            InsertDummyGuest(context, amountOfData);

            //Inserting Reviews
            InsertDummyReview(context,amountOfData);

            context.SaveChanges();
        }
        #region Henrik

        public void InsertDummyDishes(AppDbContext context, int numberOfDishes)
        {
            string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random randDishType = new Random();

            for (int i = 0; i < numberOfDishes; i++)
            {
                var dish = new Dish();

                dish.Name = "Dish" + i;
                dish.Type = dishTypeArray[randDishType.Next(dishTypeArray.Length - 1)];
                dish.Price = 10 * i;
                
                var restaurant = context.Restaurants.SingleOrDefault(r => r.Address == ("Adress" + i));
                
                if (restaurant != null)
                {
                    if (dish.RestaurantDishes == null)
                        dish.RestaurantDishes = new List<RestaurantDish>();

                    var restaurantDish = new RestaurantDish()
                    {
                        Restaurant = restaurant,
                        Dish = dish,
                    };

                    dish.RestaurantDishes.Add(restaurantDish);
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
                    if (r.Tables == null)
                        r.Tables = new List<Table>();
                    r.Tables.Add(table);
                    context.Tables.Add(table);
                }
            }
        }

        #endregion

        #region Frands
        #endregion

        #region Bertram
        public void InsertDummyRestaurant(AppDbContext context, int numberOfRestaurants)
        {
            string[] restaurantTypeArray = { "Breakfast", "Dinner", "Supper"};
            Random rand1 = new Random();

            string[] dishTypeArray = { "Appertice", "MainCourse", "Dessert", "Snack" };
            Random rand2 = new Random();

            for (int i = 0; i < numberOfRestaurants; i++)
            {
                string restaurantType = restaurantTypeArray[rand1.Next(restaurantTypeArray.Length-1)];
                string dishType = dishTypeArray[rand2.Next(dishTypeArray.Length-1)];

                //Dish dish = context.Dishes.SingleOrDefault(d => d.Type == dishType);

                Restaurant restaurant = new Restaurant()
                {
                    Name = "Restaurant" + i,
                    Type = restaurantType,
                    Address = "Address" + i
                };
                /*
                if (dish != null)
                {
                    if (restaurant.RestaurantDishes == null)
                        restaurant.RestaurantDishes = new List<RestaurantDish>();

                    var restaurantDish = new RestaurantDish()
                    {
                        Restaurant = restaurant,
                        Dish = dish
                    };
                    restaurant.RestaurantDishes.Add(restaurantDish);
                }*/

                context.Restaurants.Add(restaurant);
            }
        }

        public void InsertDummyReview(AppDbContext context, int numberOfReviews )//int numberOfRestaurantsToReview)
        {
            var restaurants = context.Restaurants;
            var guests = context.Guests;
            int reviewNumber = 0;
            Random rand = new Random();
            foreach (var r in restaurants)
            {
                foreach (var t in r.Tables)
                {
                    var review = new Review();
                    review.Restaurant = r;
                    if (t.Guests == null)
                        t.Guests = new List<Guest>();
                    review.Guests = t.Guests;
                    foreach (var g in review.Guests)
                    {
                        foreach (var gd in g.GuestDishes)
                        {
                            review.Dishes.Add(gd.Dish);
                        }
                    }

                    review.Text = "Text for review" + reviewNumber++;
                    review.Stars = rand.Next(1, 5);
                    context.Reviews.Add(review);
                }
            }

            /*
            int[] numStarsArray = { 1,2,3,4,5 };
            Random rand = new Random();
            int randomIndex = rand.Next(numStarsArray.Length);

            for (int index = 0; index < numberOfRestaurantsToReview; index++)
            {
                Restaurant restaurant = context.Restaurants.Where(r => r.Address == "Address" + index).SingleOrDefault();

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
            }*/
        }

        public void InsertDummyGuest(AppDbContext context,  int numberOfGuestsToAdd)
        {
            //for (int i = 0; i < numberOfRestaurantsToAddGuestsTo; i++)
            //{
            //    Restaurant restaurant = context.Restaurants.Where(r => r.Address == "Address" + i).SingleOrDefault();

            //    for (int j = 0; j < numberOfTablesToAddGuestsTo; j++)
            //    {
            //        Table table = context.Tables.Where(t => t.Number == j).SingleOrDefault();

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
                            Table = t,
                        };
                        if (t.Guests == null)
                            t.Guests = new List<Guest>();
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
                    if (waiter.WaiterTables == null)
                        waiter.WaiterTables = new List<WaiterTable>();

                    var waiterTable = new WaiterTable()
                    {
                        Waiter = waiter,
                        Table = t
                    };
                    waiter.WaiterTables.Add(waiterTable);
                    context.Waiters.Add(waiter);
                    waiterCount++;
                }
            }
        }
        #endregion
    }
}
