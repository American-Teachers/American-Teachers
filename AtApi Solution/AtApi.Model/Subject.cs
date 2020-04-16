using System;
using System.ComponentModel.DataAnnotations;

namespace AtApi.Model
{
   
    public class Subject 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
