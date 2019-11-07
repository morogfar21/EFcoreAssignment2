using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Assignment2.Models;

namespace Assignment2.ShadowModels
{
    public class RestaurantDish
    {
        public int RestaurantDishId { get; set; }

        //Binding between
        public Restaurant Restaurant { get; set; }
        
        public Dish Dish { get; set; }

        //PK binding
        [Required]
        public string RestaurantAddress { get; set; }
        [Required]
        public string DishType { get; set; }
    }
}
