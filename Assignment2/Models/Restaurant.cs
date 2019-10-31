using System.Collections.Generic;

namespace Assignment2.Models
{
    public class Restaurant
    {
        public string name { get; set; }
        public string type { get; set; }

        private List<Restaurant> restaurants { get; set; }

        //[Column(TypeName = "Breakfast"),
        //Column(TypeName = "Dinner")]
        //[Column(TypeName = "Dinner")]
        //[Column(TypeName = "Buffet")]
        public string address { get; set; }

        
    }
}
