using System.ComponentModel.DataAnnotations;

namespace ElectronicShop.Models
{
    public class Customer
    {
     
        public int CustomerID { get; set; }

        [Required (ErrorMessage = "Please enter Your name")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
