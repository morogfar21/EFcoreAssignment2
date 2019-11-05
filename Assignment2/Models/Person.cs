using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Person
    {
        [Key]
        public string Name { get; set; }
    }
}
