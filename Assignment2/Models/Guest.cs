using System.Collections.Generic;
using Assignment2.ShadowModels;

namespace Assignment2.Models
{
    public class Guest: Person
    {
        public List<GuestDish> GuestDishes;
        public int Time;
    }
}
