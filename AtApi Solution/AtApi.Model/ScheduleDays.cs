using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtApi.Model
{
    public enum ScheduleDays
    {
       Sunday =1,
       Monday,
       Tuesday,
       Wednesday,
       Thursday,
       Friday,
       Saturday,
       WeekDays,
       Weekends,
       EveryDay,
       MWF,
       TuTh
    }

    public class ScheduleDay : ScheduleDay<int>, IEquatable<int>
    {
        public bool Equals([AllowNull] int other)
        {
            return Id.Equals(other);
        }
    }
    public class ScheduleDay<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
      
}
