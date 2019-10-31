using System.Collections.Generic;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Table
    {
        public int number { get; set; }
        public WaiterTable WaiterTable { get; set; }
        public Assignment2.Models.Restaurant Restaurant { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
