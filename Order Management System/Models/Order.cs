namespace Order_Management_System.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal totalPrice { get; set; }
        public DateTime OrederDate { get; set; }
    }
}
