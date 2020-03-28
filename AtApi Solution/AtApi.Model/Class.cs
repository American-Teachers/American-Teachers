using System;
using System.Collections.Generic;
using System.Text;

namespace AtApi.Model
{
    public class ClassModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string Description { get; set; }
        public string Code { get; set; }

        public List<TeacherModel> Teachers { get; set; }
        public List<StudentModel> Students { get; set; }

    }
}
