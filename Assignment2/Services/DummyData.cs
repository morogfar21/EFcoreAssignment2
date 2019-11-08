using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment2.ShadowModels;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

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
            var dishCount = 0;

            var restaurants = context.Restaurants;

            foreach (var r in restaurants)
            {
                if (r.RestaurantDishes == null)
                    r.RestaurantDishes = new List<RestaurantDish>();
                for (int i = 0; i < numberOfDishes; i++)
                {
                    var dish = new Dish()
                    {
                        Name = "Dish" + dishCount++,
                        Type = dishTypeArray[randDishType.Next(dishTypeArray.Length - 1)],
                        Price = 10 * numberOfDishes
                    };
                    var rd = new RestaurantDish()
                    {
                        Dish = dish,
                        Restaurant = r
                    };
                    r.RestaurantDishes.Add(rd);
                }
                
            }

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

            context.SaveChanges();
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
            context.SaveChanges();
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
            context.SaveChanges();
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
                            if (review.Dishes == null)
                                review.Dishes = new List<Dish>();
                            review.Dishes.Add(gd.Dish);
                        }
                    }

                    review.Text = "Text for review" + reviewNumber++;
                    review.Stars = rand.Next(1, 5);
                    context.Reviews.Add(review);
                }
            }
            context.SaveChanges();

        }

        public void InsertDummyGuest(AppDbContext context,  int numberOfGuestsToAdd)
        {
            var restaurants = context.Restaurants;
            var tables = context.Tables;
            int guestCount = 0;

            foreach (var r in restaurants)
            {
                Random rand = new Random();
                List<Dish> dishes = new List<Dish>();
                foreach (var rd in r.RestaurantDishes)
                {
                    dishes.Add(rd.Dish);
                }
                foreach (var t in tables)
                {
                    for (int i = 0; i < numberOfGuestsToAdd; i++)
                    {
                        var guest = new Guest()
                        {
                            Name = "Guest" + guestCount++,
                            Time = "01:01:2000",
                            Table = t,
                        };
                        for (int index = 0; index < 3; index++)
                        {
                            var guestDish = new GuestDish()
                            {
                                Guest = guest,
                                Dish = dishes[rand.Next(0, dishes.Count - 1)]
                            };
                            if (guest.GuestDishes == null)
                                guest.GuestDishes = new List<GuestDish>();
                            guest.GuestDishes.Add(guestDish);
                        }
                        if (t.Guests == null)
                            t.Guests = new List<Guest>();
                        t.Guests.Add(guest);
                        context.Guests.Add(guest);
                    }
                }
            }
            context.SaveChanges();
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
            context.SaveChanges();
        }
        #endregion
    }
}
