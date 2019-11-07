using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Assignment2.Models;

namespace Assignment2.ShadowModels
{
    public class WaiterTable
    {
        public int WaiterTableId { get; set; }

        [Required]
        public int TableNumber { get; set; }
        [Required]
        public string WaiterName { get; set; }

        public Waiter Waiter { get; set; }
        public Table Table { get; set; }
    }
}
