using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }

        //One to Many
        private List<Review> Restaurants { get; set; }

        //One to Many
        private List<Table> Tables { get; set; }

        //[Column(TypeName = "Breakfast"),
        //Column(TypeName = "Dinner")]
        //[Column(TypeName = "Dinner")]
        //[Column(TypeName = "Buffet")]
        [Key]
        public string Address { get; set; }
    }
}
