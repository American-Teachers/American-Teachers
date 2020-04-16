using System;
using System.ComponentModel.DataAnnotations;

namespace AtApi.Model
{
   
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
