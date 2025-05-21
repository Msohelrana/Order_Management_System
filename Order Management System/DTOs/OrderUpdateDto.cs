using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class OrderUpdateDto
    {
        public Guid? ProductId { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Quantity must be at least 1!")]
        public int? Quantity { get; set; }
    }
}
