using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Order_Management_System.DTOs
{
    public class CustomerLoginDto
    {
        [Required(ErrorMessage ="Email is required!"),EmailAddress(ErrorMessage ="It's not a valid email address!")]
        public string CustomerEmail { get; set; }=string.Empty;
        [Required(ErrorMessage ="Password is required!")]
        public string CustomerPassword {  get; set; }=string.Empty;
    }
}
