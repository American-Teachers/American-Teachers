using Microsoft.AspNetCore.Identity;

namespace AtApi.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool AgreeToTermsAndCondition { get; internal set; }
    }
}
