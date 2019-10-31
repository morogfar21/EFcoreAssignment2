using System;
using System.Collections.Generic;
using System.Text;
using Assignment2.ShadowModels;

namespace Restaurant.Models
{
    public class Waiter : Person
    {
        public int Salary { get; set; }
        public List<WaiterTable> WaiterTables { get; set; }
    }
}
