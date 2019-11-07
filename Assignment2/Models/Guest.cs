using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Guest: Person
    {
        public List<GuestDish> GuestDishes { get; set; }

        [Required]
        public Review Review{ get; set; }
        [Required]
        public int Time { get; set; }
        //[Required]
        //public DateTime time;
    }
}
