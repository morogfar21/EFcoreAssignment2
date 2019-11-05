using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Waiter : Person
    {
        public int Salary { get; set; }
        public List<WaiterTable> WaiterTables { get; set; }
    }
}
