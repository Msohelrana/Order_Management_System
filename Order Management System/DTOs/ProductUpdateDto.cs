using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class ProductUpdateDto
    {
        [StringLength(100,ErrorMessage ="Proudct name can not exeed 100 character!")]
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
