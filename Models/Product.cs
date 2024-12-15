using System.ComponentModel.DataAnnotations;

namespace ProductSmallTask.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // Auto-generated ID

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
        public DateTime DateAdded = DateTime.Now;
    }
}
