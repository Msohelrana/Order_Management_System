using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage ="Product name is required!"),StringLength(100,MinimumLength =2,ErrorMessage ="Product name must contain 2 to 100 character!")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Product price is required!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product description is required!")]
        public string ProductDescription { get; set; } = string.Empty;
        [Required(ErrorMessage ="Quantity is required!")]
        public int Quantity { get; set; }
    }
}
