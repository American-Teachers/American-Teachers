using System;
using System.Collections.Generic;
using System.Text;

namespace AtApi.Model
{
    public class Parent : Person
    {
        public List<Student> Chidren { get; set; }
    }
}
