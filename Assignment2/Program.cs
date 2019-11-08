using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.Models;
using Assignment2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Marcus

            #endregion

            #region Bertram

            #endregion

            #region Henrik

            #endregion
            #region Frands

            #endregion

            Console.WriteLine("Restaurant Database");
            //Console.ReadLine();

            using (var context = new AppDbContext())
            {
                //context.Restaurants.Add(new Restaurant { Address = "Address5", Name = "RestName3", Type = "Breakfast" });

                //context.Restaurants.Add(new Restaurant { Address = "Address6", Name = "RestName3", Type = "Breakfast" });
                //context.Restaurants.Add(new Restaurant { Address = "Address7", Name = "RestName3", Type = "Breakfast" });
                //context.Dishes.Add(new Dish { Name = "DishName", Price = 100, Type = "Supper" });
                

                

                DummyData dd = new DummyData();
                dd.InsertAllDummyData(context, 10);
                
                System.Console.WriteLine("Usage:\n");
                System.Console.WriteLine("Insertions:\nInsert: \nR(Restaurant)\nD(Dish)\nG(Guest)\nV(Review)\nT(Table)\nW(Waiter)");
                System.Console.WriteLine("\nView Query: \nqr(Restaurants general information)\nqv(Restaurants based on table reviews)\nqt(Restaurants by type");
                System.Console.WriteLine("\nExit: x");
                

                while (true)
                {
                    System.Console.WriteLine("Type command");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "r":
                            Restaurant restaurant = Create.CreateRestaurant(context);
                            if (restaurant == null)
                                break;
                            context.Restaurants.Add(restaurant);
                            context.SaveChanges();
                            break;

                        case "d":
                            Dish dish = Create.CreateDish(context);
                            if (dish == null)
                                break;
                            context.Dishes.Add(dish);
                            context.SaveChanges();
                            break;

                        case "g":
                            Guest guest = Create.CreateGuest(context);
                            context.Guests.Add(guest);
                            context.SaveChanges();
                            break;

                        /*case "p":
                            Person person = Create.CreatePerson(context);
                            context.Persons.Add(person);
                            context.SaveChanges();
                            break;
                            */

                        case "v":
                            Review review = Create.CreateReview(context);
                            context.Reviews.Add(review);
                            context.SaveChanges();
                            break;

                        case "t":
                            Table table = Create.CreateTable(context);
                            context.Tables.Add(table);
                            context.SaveChanges();
                            break;

                        case "w":
                            Waiter waiter = Create.CreateWaiter(context);
                            context.Waiters.Add(waiter);
                            context.SaveChanges();
                            break;

                        case "qr":
                            View.ListRestaurantGeneralInformation(context);
                            break;

                        case "qv":
                            List<Restaurant> restaurants =
                                context.Restaurants.Include(r => r.RestaurantDishes).ThenInclude(rd => rd.Dish).ToList();

                            foreach (var r in restaurants)
                            {
                                Console.WriteLine($"Name: {r.Name}, Address: {r.Address}");
                            }

                            View.ListRestaurantBasedOnTableReviews(context);
                            break;

                        case "qt":
                            View.ListRestaurantByType(context);
                            break;

                        case "x":
                            System.Console.WriteLine("Exiting....");
                            return;

                        default:
                            System.Console.WriteLine("Unknown command");
                            break;
                    }
                }
            }
        }
    }
}
