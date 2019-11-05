using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;

namespace Assignment2.Services
{
    public static class Create
    {
        #region Marcus
        #endregion

        #region Bertram
        #endregion

        #region Henrik
        #endregion

        #region Frands
        public static Table CreateTable(AppDbContext context)
        {
            Restaurant rest = FindRestaurant(context);

            Console.Write("Table number: ");
            int number = int.Parse(Console.ReadLine());

            return new Table()
            {
                Number = number,
                Restaurant = rest
            };

            //[Key]
            //public int Number { get; set; }
            //public List<WaiterTable> WaiterTables { get; set; }
            //[Required]
            //public Restaurant Restaurant { get; set; }
            //public List<Guest> Guests { get; set; }
            
        }
        #endregion
    }
}
