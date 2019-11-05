using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Table
    {
        [Key]
        public int Number { get; set; }
        public List<WaiterTable> WaiterTables { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
