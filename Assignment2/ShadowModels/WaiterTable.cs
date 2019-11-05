using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Models;

namespace Assignment2.ShadowModels
{
    public class WaiterTable
    {
        public Waiter Waiter { get; set; }
        public Table Table { get; set; }
    }
}
