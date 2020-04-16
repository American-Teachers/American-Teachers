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

    
    public class ScheduleDay
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
      
}
