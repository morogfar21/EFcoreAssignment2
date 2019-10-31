using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Models;

namespace Assignment2.ShadowModels
{
    public class GuestDish
    {
        public Dish Dish { get; set; }
        public Guest Guest { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
