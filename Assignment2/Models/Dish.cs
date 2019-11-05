using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.ShadowModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment2.Models
{
    public class Dish
    {
        [Key]
        public string Type { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public Review Review { get; set; }

        public List<RestaurantDish> RestaurantDishes { get; set; }
        public List<GuestDish> GuestDishes { get; set; }

    }
}
