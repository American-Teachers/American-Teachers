using System;
using System.ComponentModel.DataAnnotations;

namespace AtApi.Model
{
    public class School : School<int> { }
    public class School<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
