using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
    }
}
