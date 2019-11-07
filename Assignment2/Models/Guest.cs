using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Guest: Person
    {
        public List<GuestDish> GuestDishes { get; set; }


        public Review Review{ get; set; }
        [Required]
        public string Time { get; set; }
        
        public Table Table { get; set; }
    }
}
