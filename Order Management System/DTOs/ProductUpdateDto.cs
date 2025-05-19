using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class ProductUpdateDto
    {
        [StringLength(100,MinimumLength =2,ErrorMessage ="Proudct name must be greater than 2 characters!")]
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
    }
}
