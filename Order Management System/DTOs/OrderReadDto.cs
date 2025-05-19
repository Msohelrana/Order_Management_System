namespace Order_Management_System.DTOs
{
    public class OrderReadDto
    {
        public Guid OrderId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string CustomerName{ get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal totalPrice { get; set; }
    }
}
