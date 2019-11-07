using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment2.ShadowModels
{
    public class GuestDish
    {
        //[Key]
        public int GuestDishId { get; set; }
        
        public Dish Dish { get; set; }
        
        public Guest Guest { get; set; }

        [Required]
        public string GuestName { get; set; }
        [Required]
        public string DishName { get; set; }

    }
}
