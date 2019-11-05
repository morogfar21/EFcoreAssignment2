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
        [Key]
        public int GuestDishId { get; set; }
        [Required]
        public Dish Dish { get; set; }
        [Required]
        public Guest Guest { get; set; }

        public string GuestName { get; set; }
        public string DishName { get; set; }

    }
}
