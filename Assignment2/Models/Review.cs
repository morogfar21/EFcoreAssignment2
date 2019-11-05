using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }

        //Many to One
        [Required]
        public Restaurant Restaurant { get; set; }

        //One to Many
        public List<Guest> Guests { get; set; }

        //One to Many
        public List<Dish> Dishes { get; set; }
    }
}
