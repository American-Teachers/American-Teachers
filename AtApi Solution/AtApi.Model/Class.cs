using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtApi.Model
{

    public class Class
    {
        [Key]
        public int Id { get; set; }
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

      
    }
}
