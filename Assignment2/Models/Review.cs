using System.Collections.Generic;

namespace Assignment2.Models
{
    public class Review
    {
        public string Text { get; set; }
        public int Stars { get; set; }

        //Many to One
        private Restaurant Restaurant { get; set; }

        //One to Many
        private List<Guest> Guests { get; set; }

        //One to Many
        private List<Dish> Dishes { get; set; }
    }
}
