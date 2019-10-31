using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;

namespace Assignment2.ShadowModels
{
    public class GuestDish
    {
        public Dish Dish { get; set; }
        public Guest Guest { get; set; }
        public string GuestName { get; set; }
        public string DishType { get; set; }

    }
}
