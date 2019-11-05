using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }

        //One to Many
        public List<Review> Restaurants { get; set; }

        //One to Many
        public List<Table> Tables { get; set; }

        //Many to Many
        public List<RestaurantDish> RestaurantDishes { get; set; }

        //[Column(TypeName = "Breakfast"),
        //Column(TypeName = "Dinner")]
        //[Column(TypeName = "Dinner")]
        //[Column(TypeName = "Buffet")]
        [Key]
        public string Address { get; set; }
    }
}
