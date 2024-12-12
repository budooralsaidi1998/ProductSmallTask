using System.ComponentModel.DataAnnotations;

namespace ProductSmallTask.DOTS
{
    public class ProductInputDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }  // Required

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }  // Required, must be greater than 0

        public string Category { get; set; }
    }
}
