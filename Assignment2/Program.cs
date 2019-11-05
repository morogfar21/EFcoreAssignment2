using System;
using Assignment2.Models;
using Assignment2.Services;

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
                System.Console.WriteLine("Usage");
                System.Console.WriteLine("Insert: R(Restaurant), D(Dish), G(Guest), P(Person), V(Review), T(Table), W(Waiter)");
                //System.Console.WriteLine("Query: qr(Restaurants), qd(Dishes)");
                System.Console.WriteLine("Exit: x");

                while (true)
                {
                    System.Console.WriteLine("Type command");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "r":
                            Restaurant restaurant = Create.CreateRestaurant(context);
                            context.Restaurants.Add(restaurant);
                            context.SaveChanges();
                            break;

                        case "d":
                            Dish dish = Create.CreateDish(context);
                            context.Dishes.Add(dish);
                            context.SaveChanges();
                            break;

                        case "g":
                            Guest guest = Create.CreateGuest(context);
                            context.Guests.Add(guest);
                            context.SaveChanges();
                            break;

                        case "p":
                            Person person = Create.CreatePerson(context);
                            context.Persons.Add(person);
                            context.SaveChanges();
                            break;

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

                        //case "qa":
                        //    ListAuthors(context);
                        //    break;

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
