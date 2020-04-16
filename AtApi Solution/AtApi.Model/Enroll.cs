using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtApi.Model
{
    public class Enrollment : Enrollment<int>, IEquatable<int> { };
    public class Enrollment<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public bool Equals([AllowNull] int other)
        {
            return Id.Equals(other);
        }
    }

     
}
