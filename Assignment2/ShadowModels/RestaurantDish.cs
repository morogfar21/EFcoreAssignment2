using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;

namespace Assignment2.ShadowModels
{
    public class RestaurantDish
    {
        public Restaurant Restaurant { get; set; }
        public Dish Dish { get; set; }

        public string RestaurantName { get; set; }
        public string DishType { get; set; }
    }
}
