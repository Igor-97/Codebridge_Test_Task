using System.ComponentModel.DataAnnotations;

namespace REST_API_Task.Models
{
    public class Dog
    {
        [Key]
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }
    }
}
