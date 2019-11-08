using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;
using Assignment2.ShadowModels;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Assignment2.Services
{
    public static class Create
    {
        #region Marcus
        /*
        public static Person CreatePerson (AppDbContext context)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Person person = new Person()
            {
                Name = name
            };
            return person;

        }
        */
        public static Guest CreateGuest(AppDbContext context)
        {
            Table table = Find.FindTable(context);

            Console.Write("Guest name: ");
            var name = Console.ReadLine();

            Console.Write("date of restaurant visit(dd:mm:yyyy) : ");
            var time = Console.ReadLine();

            Guest guest = new Guest()
            {
                Name = name,
                Time = time
            };

            if (table != null)
            {
                guest.Table = table;
            }

            Console.WriteLine("Number of dishes: ");
            var numberOfDishes = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfDishes; i++)
            {
                var dish = CreateDish(context);
                var guestDish = new GuestDish()
                {
                    Dish = dish,
                    Guest = guest
                };
            }

            return guest;
        }
        
        #endregion

        #region Bertram
        public static Restaurant CreateRestaurant(AppDbContext context)
        {
            var restaurant = Find.FindRestaurant(context);
            if (restaurant == null)
            {
                Dish dish = Find.FindDish(context);

                Console.Write("Name of restaurant: ");
                string name = Console.ReadLine();

                Console.Write("Type (Breakfast, Dinner, Buffet...): ");
                string type = Console.ReadLine();

                Console.Write("Restaurant address: ");
                string address = Console.ReadLine();

                restaurant.Name = name;
                restaurant.Type = type;
                restaurant.Address = address;

                if (dish != null)
                {
                    restaurant.RestaurantDishes = new List<RestaurantDish>()
                    {
                        new RestaurantDish()
                        {
                            Restaurant = restaurant,
                            Dish = dish
                            //RestaurantAddress = address,
                            //DishType = type
                        }
                    };
                }
                return restaurant;
            }

            return null;
        }

        public static Review CreateReview(AppDbContext context)
        {
            Review review = new Review();
            Restaurant restaurant = Find.FindRestaurant(context);

            if (restaurant == null)
            {
               review.Restaurant = CreateRestaurant(context);
            }

            Console.WriteLine("How many guests ate?: ");
            string numOfGuests = Console.ReadLine();

            for (int i = 0; i < Int32.Parse(numOfGuests); i++)
            {
                var guest = Find.FindGuest(context);
                if (guest == null)
                    guest = CreateGuest(context);
                
                review.Guests.Add(guest);
            }

            Console.Write("Text in review: ");
            review.Text = Console.ReadLine();

            Console.Write("Stars: ");
            review.Stars = double.Parse(Console.ReadLine());

            foreach (var g in review.Guests)
            {
                foreach (var gd in g.GuestDishes)
                {
                    review.Dishes.Add(gd.Dish);
                }
            }
            
            return review;
        }

        #endregion

        #region Henrik

        public static Dish CreateDish(AppDbContext context)
        {
            var dish = Find.FindDish(context);
            if (dish == null)
            {
                var restaurant = Find.FindRestaurant(context);
                var guest = Find.FindGuest(context);

                Console.WriteLine("Input Dish Name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Input Type: ");
                var type = Console.ReadLine();

                Console.WriteLine("Input Price: ");
                var price = int.Parse(Console.ReadLine());

                dish.Name = name;
                dish.Type = type;
                dish.Price = price;

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

                if (guest != null)
                {
                    dish.GuestDishes = new List<GuestDish>()
                    {
                        new GuestDish()
                        {
                            Guest = guest,
                            Dish = dish,
                        }
                    };
                }
                return dish;
            }

            return null;
        }

        #endregion

        #region Frands
        public static Table CreateTable(AppDbContext context)
        {
            Restaurant restaurant = Find.FindRestaurant(context);
            Waiter waiter = Find.FindWaiter(context);


            Console.Write("Number of table: ");
            int number = int.Parse(Console.ReadLine());

            Table table = new Table()
            {
                Number = number,
                Restaurant = restaurant
            };

            if (waiter != null)
            {
                table.WaiterTables = new List<WaiterTable>()
                {
                    new WaiterTable()
                    {
                        Waiter = waiter,
                        Table = table
                    }
                };
            }

            return table;
        }

        public static Waiter CreateWaiter(AppDbContext context)
        {
            Table table = Find.FindTable(context);

            Console.Write("Name of waiter: ");
            string name = Console.ReadLine();

            Console.Write("Salary: ");
            int salary = int.Parse(Console.ReadLine());

            Waiter waiter = new Waiter()
            {
                Name = name,
                Salary = salary
            };

            if (table != null)
            {
                waiter.WaiterTables = new List<WaiterTable>()
                {
                    new WaiterTable()
                    {
                        Waiter = waiter,
                        Table = table
                    }
                };
            }
            return waiter;
        }

        #endregion
    }
}
