using System;
using System.Collections.Generic;
using System.Text;

namespace AtApi.Model
{
    public class EnrollModel
    {
        public int ClassId { get; set; }
        public ClassModel Class { get; set; }
        public int StudentId { get; set; }
    }
}
