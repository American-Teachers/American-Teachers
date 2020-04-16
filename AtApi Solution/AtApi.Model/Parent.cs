using System.Collections.Generic;

namespace AtApi.Model
{
    public class Parent : Person
    {
        public List<Student> Chidren { get; set; }
    }
}
