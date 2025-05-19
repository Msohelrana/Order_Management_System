namespace Order_Management_System.DTOs
{
    public class ProductReadDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
