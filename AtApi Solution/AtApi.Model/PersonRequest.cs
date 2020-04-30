
namespace AtApi.Model
{
    public class PersonRequest
    {
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }
        public string Role { get; set; }

        public string AspUserId { get; set; }

        public override string ToString()
        {
            return "{" + $"'EmailAddress':'{EmailAddress}', 'Role':'{Role}', 'AspUserId':'{AspUserId}'" + "}";
        }
    }
}
