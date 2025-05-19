using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class OrderUpdateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
