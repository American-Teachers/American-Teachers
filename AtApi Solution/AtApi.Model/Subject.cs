using System;
using System.ComponentModel.DataAnnotations;

namespace AtApi.Model
{
    public class Subject : Subject<int> { }
    public class Subject<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
