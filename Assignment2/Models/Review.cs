using System.Collections.Generic;

namespace Assignment2.Models
{
    public class Review
    {
        public string text { get; set; }
        public int stars { get; set; }

        private List<Assignment2.Models.Restaurant> restaurantreviews { get; set; }
    }
}
