namespace Order_Management_System.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } =string.Empty;
        public float Price { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
