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
            Console.WriteLine("Restaurant Database");
            //Console.ReadLine();

            using (var context = new AppDbContext())
            {
                Console.WriteLine("!!!Attention!!!\nIf you get errors use \"Update-Database 0 -> Update-Database\" in package manager console, to reset the database\n!!!Attention!!!\n\n");
                while (true)
                {
                    ShowCommands(context);
                }
            }
        }


        private static void ShowCommands(AppDbContext context)
        {
            System.Console.WriteLine("Usage:\n");
            System.Console.WriteLine("Insert DummyData: 1\n Clear Database: 2");
            System.Console.WriteLine(
                "Insertions:\nInsert: \nR(Restaurant)\nD(Dish)\nG(Guest)\nV(Review)\nT(Table)\nW(Waiter)");
            System.Console.WriteLine(
                "\nView Query: \nqr(Restaurants general information)\nqv(Restaurants based on table reviews)\nqt(Restaurants by type");
            System.Console.WriteLine("\nExit: x");

            System.Console.WriteLine("Type command");
            string line = Console.ReadLine();

            switch (line)
            {
                case "1":
                    DummyData.InsertAllDummyData(context, 5);
                    Console.WriteLine("DummyDataInserted");
                    break;
                case "2":
                    ClearDatabase.DeleteData(context);
                    Console.WriteLine("Database Cleared");
                    break;
                case "r":
                    var restaurant = Create.CreateRestaurant(context);
                    if (restaurant == null)
                        break;
                    context.Restaurants.Add(restaurant);
                    context.SaveChanges();
                    break;

                case "d":
                    var dish = Create.CreateDish(context);
                    if (dish == null)
                        break;
                    context.Dishes.Add(dish);
                    context.SaveChanges();
                    break;

                case "g":
                    var guest = Create.CreateGuest(context);
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
                    var review = Create.CreateReview(context);
                    context.Reviews.Add(review);
                    context.SaveChanges();
                    break;

                case "t":
                    var table = Create.CreateTable(context);
                    context.Tables.Add(table);
                    context.SaveChanges();
                    break;

                case "w":
                    var waiter = Create.CreateWaiter(context);
                    context.Waiters.Add(waiter);
                    context.SaveChanges();
                    break;

                case "qr":
                    View.ListRestaurantGeneralInformation(context);
                    break;

                case "qv":
                    View.ListRestaurantBasedOnTableReviews2(context);
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
