using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class CustomerUpdateDto
    {
        [StringLength(100,ErrorMessage = "Customer Name must contain 2 to 100 character!")]
        public string CustomerName { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "It's not a valid email address!")]
        public string CustomerEmail { get; set; } = string.Empty;
        [Phone(ErrorMessage = "it's not a valid phone number!")]
        public string CustomerPassword {  get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name must contain between 2 to 100 character!")]
        public string CustomerCity { get; set; } = string.Empty;
    }
}
