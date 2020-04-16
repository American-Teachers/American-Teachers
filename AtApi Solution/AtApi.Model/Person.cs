using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtApi.Model
{
    
    public class Person 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Title { get; set; }
        public string? Suffix { get; set; }

        public string? PreferredName { get; set; }
        public bool Equals([AllowNull] int other)
        {
            return Id.Equals(other);
        }
    }
}
