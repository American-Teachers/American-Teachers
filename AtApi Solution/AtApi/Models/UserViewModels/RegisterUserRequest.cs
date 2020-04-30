using System.ComponentModel.DataAnnotations;

namespace AtApi.Models.UserViewModels
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        public string UserName { get;  set; }

        [Required]
        public string Role { get; set; }

        public string PreferredName { get; set; }
    }
}
