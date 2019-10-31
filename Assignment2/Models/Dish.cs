using System.Collections.Generic;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Dish
    {
        public float Price { get; set; }
        public string Type { get; set; }

        public List<GuestDish> GuestDishes { get; set; }
        public Review Review { get; set; }

        public List<RestaurantDish> RestaurantDishes { get; set; }


    }
}
