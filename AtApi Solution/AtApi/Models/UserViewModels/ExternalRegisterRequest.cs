using System.ComponentModel.DataAnnotations;

namespace AtApi.Models.UserViewModels
{
    public class ExternalRegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "First Name is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "Last Name is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Do you agree to the terms and conditions?")]
        public bool AgreeToTermsAndCondition { get; set; }
    }
}
