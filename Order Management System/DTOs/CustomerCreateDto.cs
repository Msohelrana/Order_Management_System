using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class CustomerCreateDto
    {
        [Required(ErrorMessage="Customer Name is required!"),StringLength(30,MinimumLength =2, ErrorMessage="Customer Name must be less than 30 character")]
        public string CustomerName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Customer email address is required!"), EmailAddress(ErrorMessage ="It's not a valid email address!")]
        public string CustomerEmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "Customer phone number is required!"), Phone(ErrorMessage ="it's not a valid phone number!")]
        public string CustomerPhone { get; set; } = string.Empty;
        [Required(ErrorMessage ="Customer city is required!"),StringLength(100,MinimumLength =2,ErrorMessage ="City name must contain between 2 to 100 character!")]
        public string CustomerCity { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
