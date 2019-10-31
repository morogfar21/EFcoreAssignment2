using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;

namespace Restaurant.Models
{
    public class Dish : Restaurant
    {
        public float Price { get; set; }
        public string Type { get; set; }

        public List<GuestDish> GuestDishes { get; set; }
        public Review Review { get; set; }

        public List<RestaurantDish> RestaurantDishes { get; set; }


    }
}
