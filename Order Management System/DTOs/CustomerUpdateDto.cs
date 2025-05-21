using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class CustomerUpdateDto
    {
        [StringLength(100,MinimumLength =2, ErrorMessage = "Customer Name must contain 2 to 100 character!")]
        public string? CustomerName { get; set; }
        [EmailAddress(ErrorMessage = "It's not a valid email address!")]
        public string? CustomerEmail { get; set; }
        public string? CustomerPassword {  get; set; }
        [Phone(ErrorMessage = "it's not a valid phone number!")]
        public string? CustomerPhone { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name must contain between 2 to 100 character!")]
        public string? CustomerCity { get; set; }
    }
}
