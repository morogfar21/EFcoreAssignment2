using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;

namespace Restaurant.Models
{
    public class Table
    {
        public int number { get; set; }
        public WaiterTable WaiterTable { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
