using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.Models;

namespace Assignment2.ShadowModels
{
    public class WaiterTable
    {

        public int TableNumber { get; set; }

        public string WaiterName { get; set; }

        public Waiter Waiter { get; set; }
        public Table Table { get; set; }
    }
}
