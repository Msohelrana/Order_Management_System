using System.Security;

namespace Order_Management_System.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set;} = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerCity { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
