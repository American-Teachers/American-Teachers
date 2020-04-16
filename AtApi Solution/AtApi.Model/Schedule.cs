using System;
using System.ComponentModel.DataAnnotations;

namespace AtApi.Model
{
    public class Schedule : Schedule<int>
    {

    }
    public class Schedule<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ScheduleDay Day { get; set; }
        public string Time { get; set; }
    }
}