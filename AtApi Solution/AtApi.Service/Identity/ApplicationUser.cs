using Microsoft.AspNetCore.Identity;

namespace AtApi.Service.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AgreeToTermsAndCondition { get; set; }
    }
}
