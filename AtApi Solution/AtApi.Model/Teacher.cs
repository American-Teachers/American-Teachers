using System;
using System.Collections.Generic;

namespace AtApi.Model
{
    public class Teacher : Person
    {
        public List<School> Schools { get; set; }
    }
}
