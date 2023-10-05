using System.ComponentModel.DataAnnotations;

namespace IEEEWebsite.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Enter a Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(8, ErrorMessage ="Min Length is 8")]
        [MaxLength(30, ErrorMessage ="Max Length is 30")]
        public string Password { get; set; }
    
    }
}
