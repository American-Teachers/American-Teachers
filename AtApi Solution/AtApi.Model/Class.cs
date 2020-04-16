using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AtApi.Model
{
    public class Class : Class<int>, IEquatable<int>
    {
       
    }
    public class Class<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
        public string Code { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

        public int EstimatedNumberOfStudents { get; set; }

        public bool Equals([AllowNull] int other)
        {
            return Id.Equals(other);
        }
    }
}
