using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class OrderCreateDto
    {
        [Required(ErrorMessage ="Product Id is Requird!")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage ="Customer Id is required!")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage ="Product quantity is required!")]
        public int Quantity { get; set; }
    }
}
