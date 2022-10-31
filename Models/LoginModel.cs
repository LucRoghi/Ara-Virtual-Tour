using System.ComponentModel.DataAnnotations;

namespace AraVirtualTour.Models
{
    public class LoginModel
    {
        [Required (ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}