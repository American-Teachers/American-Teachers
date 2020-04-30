using System.ComponentModel.DataAnnotations;

namespace AtApi.Models.UserViewModels
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First Name is Required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last Name is Required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        public bool AgreeToTermsAndCondition { get; set; }
    }
}
