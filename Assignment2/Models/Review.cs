using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public double Stars { get; set; }

        //Many to One
        [Required]
        public Restaurant Restaurant { get; set; }

        [Required]
        public List<Guest> Guests { get; set; }

        [Required]
        public List<Dish> Dishes { get; set; }
    }
}
