using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;

namespace Restaurant.Models
{
    public class Dish
    {
        public float Price { get; set; }
        public string Type { get; set; }

        public List<GuestDish> GuestDish { get; set; }
        public Review Review { get; set; }

        public RestaurantDish RestaurantDish { get; set; }


    }
}
